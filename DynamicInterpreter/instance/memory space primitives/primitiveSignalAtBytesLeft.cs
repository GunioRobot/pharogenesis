primitiveSignalAtBytesLeft
	"Set the low-water mark for free space. When the free space falls below this level, the new and new: primitives fail and system attempts to allocate space (e.g., to create a method context) cause the low-space semaphore (if one is registered) to be signalled."

	| bytes |
	bytes _ self popInteger.
	successFlag
		ifTrue: [ lowSpaceThreshold _ bytes ]
		ifFalse: [
			lowSpaceThreshold _ 0.
			self unPop: 1.
		].