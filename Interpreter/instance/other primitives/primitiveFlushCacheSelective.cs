primitiveFlushCacheSelective
	"The receiver is a message selector.  Clear all entries in the method lookup cache with this selector, presumably because an associated method has been redefined."
	| selector nCols |
	selector _ self stackTop.

	"Flush all entries of the method cache that refer to the given selector."
	nCols _ MethodCacheSize // MethodCacheEntries.
	1 to: MethodCacheEntries do:
		[:i | (methodCache at: i) = selector ifTrue:
			[0 to: nCols-1 do:
				[:col | methodCache at: i+(MethodCacheEntries*col) put: 0]]]