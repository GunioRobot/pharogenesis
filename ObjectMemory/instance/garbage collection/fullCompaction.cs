fullCompaction
	"Move all accessible objects down to leave one big free chunk at the end of memory."
	"Assume: Incremental GC has just been done to maximimize forwarding table space."

	"need not move objects below the first free chunk"
	compStart _ self lowestFreeAfter: (self startOfMemory).
	compStart = freeBlock ifTrue: [
		"memory is already compact; only free chunk is at the end"
		^ self initializeMemoryFirstFree: freeBlock
	].

	"work up through memory until all free space is at the end"
	[compStart < freeBlock] whileTrue: [
		"free chunk returned by incCompBody becomes start of next compaction"
		compStart _ self incCompBody.  "bubble of free space moves up each time"
	].