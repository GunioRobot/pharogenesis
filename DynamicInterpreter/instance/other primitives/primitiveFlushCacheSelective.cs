primitiveFlushCacheSelective
	"The receiver is a message selector.  Clear all entries in the method lookup cache with this selector, presumably because an associated method has been redefined."
	| selector |
	selector _ self stackTop.
	self flushMethodCacheSelective: selector.
