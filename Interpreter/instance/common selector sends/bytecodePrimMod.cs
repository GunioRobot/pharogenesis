bytecodePrimMod
	| mod |
	successFlag _ true.
	mod _ self doPrimitiveMod: (self internalStackValue: 1) by: (self internalStackValue: 0).
	successFlag ifTrue:
		[self internalPop: 2 thenPush: (self integerObjectOf: mod).
		^ self fetchNextBytecode "success"].

	messageSelector _ self specialSelector: 10.
	argumentCount _ 1.
	self normalSend