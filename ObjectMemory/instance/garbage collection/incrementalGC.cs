incrementalGC
	"Do a mark/sweep garbage collection of just the young object area of object memory (i.e., objects above youngStart), using the root table to identify objects containing pointers to young objects from the old object area."

	| survivorCount startTime |
	self inline: false.
	rootTableCount >= RootTableSize ifTrue: [
		"root table overflow; cannot do an incremental GC (this should be very rare)"
		statRootTableOverflows _ statRootTableOverflows + 1.
		^ self fullGC].

	DoAssertionChecks ifTrue: [self reverseDisplayFrom: 8 to: 15].
	DoAssertionChecks ifTrue: [self validateRoots].
	self preGCAction: false.
	"incremental GC and compaction"
	startTime _ self ioMicroMSecs.
	self markPhase.
	survivorCount _ self sweepPhase.
	self incrementalCompaction.
	allocationCount _ 0.
	statIncrGCs _ statIncrGCs + 1.
	statIncrGCMSecs _ statIncrGCMSecs + (self ioMicroMSecs - startTime).

	survivorCount > tenuringThreshold ifTrue: [
		"move up the young space boundary if there are too many survivors;
		 this limits the number of objects that must be processed on future
		 incremental GC's"

		statTenures _ statTenures + 1.
		self clearRootsTable.
		youngStart _ freeBlock.  "reset the young object boundary"
	].
	self postGCAction.
	DoAssertionChecks ifTrue: [self reverseDisplayFrom: 8 to: 15].
