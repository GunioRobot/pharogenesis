initializeMemoryFirstFree: firstFree 
	"Initialize endOfMemory to the top of oop storage space, reserving some space for forwarding blocks, and create the freeBlock from which space is allocated. Also create a fake free chunk at endOfMemory to act as a sentinal for memory scans."
	"Note: The amount of space reserved for forwarding blocks should be chosen to ensure that incremental compactions can usually be done in a single pass. However, there should be enough forwarding blocks so a full compaction can be done in a reasonable number of passes, say ten. (A full compaction requires N object-moving passes, where N = number of non-garbage objects / number of forwarding blocks)."

	| fwdBlockBytes |
	"reserve space for forwarding blocks"
	fwdBlockBytes _ MinimumForwardTableBytes.
	(memoryLimit - fwdBlockBytes) >= (firstFree + BaseHeaderSize) ifFalse: [
		"reserve enough space for a minimal free block of BaseHeaderSize bytes"
		fwdBlockBytes _ memoryLimit - (firstFree + BaseHeaderSize).
	].

	"set endOfMemory and initialize freeBlock"
	endOfMemory _ memoryLimit - fwdBlockBytes.
	freeBlock _ firstFree.
	self setSizeOfFree: freeBlock to: (endOfMemory - firstFree).  "bytes available for oops"

	"make a fake free chunk at endOfMemory for use as a sentinal in memory scans"
	self setSizeOfFree: endOfMemory to: BaseHeaderSize.

	DoAssertionChecks ifTrue: [
		((freeBlock < endOfMemory) and: [endOfMemory < memoryLimit])
			ifFalse: [ self error: 'error in free space computation' ].	
		(self oopFromChunk: endOfMemory) = endOfMemory
			ifFalse: [ self error: 'header format must have changed' ].
		(self objectAfter: freeBlock) = endOfMemory
			ifFalse: [ self error: 'free block not properly initialized' ].
	].