allocateChunk: byteSize 
	"Allocate a chunk of the given size. Sender must be sure that the requested size includes enough space for the header word(s)."
	"Details: To limit the time per incremental GC, do one every so many allocations."

	| enoughSpace newFreeSize newChunk |
	self inline: true.
	allocationCount >= allocationsBetweenGCs ifTrue: [
		"do an incremental GC every so many allocations to keep pauses short"
		self incrementalGC.
	].

	enoughSpace _ self sufficientSpaceToAllocate: byteSize.
	enoughSpace ifFalse: [
		"signal that space is running low, put proceed with allocation if possible"
		signalLowSpace _ true.
		lowSpaceThreshold _ 0.  "disable additional interrupts until lowSpaceThreshold is reset by image"
		interruptCheckCounter _ 0.
	].

	(self cCoerce: (self sizeOfFree: freeBlock) to: 'unsigned ')
		< (self cCoerce: (byteSize + BaseHeaderSize) to: 'unsigned ') ifTrue: [
		self error: 'out of memory'.
	].

	"if we get here, there is enough space for allocation to succeed"
	newFreeSize _ (self sizeOfFree: freeBlock) - byteSize.
	newChunk _ freeBlock.
	freeBlock _ freeBlock + byteSize.
	"Assume: client will initialize object header of free chunk, so following is not needed:"
	"self setSizeOfFree: newChunk to: byteSize."
	self setSizeOfFree: freeBlock to: newFreeSize.
	allocationCount _ allocationCount + 1.

	^ newChunk