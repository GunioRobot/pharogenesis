fullGC
	"Do a mark/sweep garbage collection of the entire object memory. Free inaccessible objects but do not move them."

	| startTime |
	self inline: false.
	self preGCAction: true.
	startTime _ self ioMicroMSecs.
	self clearRootsTable.
	youngStart _ self startOfMemory.  "process all of memory"
	self markPhase.
	self sweepPhase.
	self fullCompaction.
	allocationCount _ 0.
	statFullGCs _ statFullGCs + 1.
	statFullGCMSecs _ statFullGCMSecs + (self ioMicroMSecs - startTime).

	youngStart _ freeBlock.  "reset the young object boundary"
	self postGCAction.