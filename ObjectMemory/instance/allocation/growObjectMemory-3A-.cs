growObjectMemory: delta 
	"Attempt to grow the object memory by the given delta 
	amount "
	| limit |
	limit _ self sqGrowMemory: memoryLimit By: delta.
	limit = memoryLimit
		ifFalse: [memoryLimit _ limit - 24.
			"remove a tad for safety"
			self initializeMemoryFirstFree: freeBlock]