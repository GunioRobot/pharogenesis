fullGC
	"Do a mark/sweep garbage collection of the entire object memory. Free inaccessible objects but do not move them."

	| startTime |
	self inline: false.
	DoAssertionChecks ifTrue: [self reverseDisplayFrom: 0 to: 7].
	self preGCAction: true.
	startTime _ self ioMicroMSecs.
	self clearRootsTable.
	youngStart _ self startOfMemory.  "process all of memory"
	self markPhase.
	"Sweep phase returns the number of survivors.
	Use the up-to-date version instead the one from startup."
	totalObjectCount _ self sweepPhase.
	self fullCompaction.
	allocationCount _ 0.
	statFullGCs _ statFullGCs + 1.
	statFullGCMSecs _ statFullGCMSecs + (self ioMicroMSecs - startTime).

	youngStart _ freeBlock.  "reset the young object boundary"
	self postGCAction.
	DoAssertionChecks ifTrue: [self reverseDisplayFrom: 0 to: 7].
