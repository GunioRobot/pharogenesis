primitiveFullGC
	"Do a quick, incremental garbage collection and return the number of bytes available."

	self pop: 1.
	self incrementalGC.  "maximimize space for forwarding table"
	self fullGC.
	self pushInteger: (self sizeOfFree: freeBlock).