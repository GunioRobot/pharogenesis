primitiveBytesLeft
	"Reports bytes available at this moment. For more meaningful results, calls to this primitive should be preceeded by a full or incremental garbage collection."

	self pop: 1.
	self pushInteger: (self sizeOfFree: freeBlock).