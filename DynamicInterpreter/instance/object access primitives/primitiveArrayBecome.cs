primitiveArrayBecome
	"We must flush the method cache here, to eliminate stale references
	to mutated classes and/or selectors."

	| arg rcvr |
	arg _ self popStack.
	rcvr _ self stackTop.
	self flushMethodCache.
	self flushInlineCache.
	self success: (self become: rcvr with: arg).
	successFlag ifFalse: [ self unPop: 1 ].