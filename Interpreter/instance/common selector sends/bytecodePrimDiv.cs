bytecodePrimDiv
	| quotient |
	successFlag _ true.
	quotient _ self doPrimitiveDiv: (self internalStackValue: 1) by: (self internalStackValue: 0).
	successFlag ifTrue: [self internalPop: 2 thenPush: (self integerObjectOf: quotient).
		^ self fetchNextBytecode "success"].

	messageSelector _ self specialSelector: 13.
	argumentCount _ 1.
	self normalSend