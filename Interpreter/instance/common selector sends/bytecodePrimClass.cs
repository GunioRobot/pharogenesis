bytecodePrimClass
	| rcvr |
	rcvr _ self internalStackTop.
	self internalPop: 1 thenPush: (self fetchClassOf: rcvr).
	self fetchNextBytecode.
