shrinkObjectMemory: delta 
	"Attempt to shrink the object memory by the given delta 
	amount "
	| limit |
	limit _ self sqShrinkMemory: memoryLimit By: delta.
	limit = memoryLimit
		ifFalse: [memoryLimit _ limit - 24.
			"remove a tad for safety"
			self initializeMemoryFirstFree: freeBlock]