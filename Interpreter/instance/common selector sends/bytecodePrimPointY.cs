bytecodePrimPointY

	| rcvr |
	successFlag _ true.
	rcvr _ self internalStackTop.
	self assertClassOf: rcvr is: (self splObj: ClassPoint).
	successFlag
		ifTrue: [self internalPop: 1 thenPush: (self fetchPointer: YIndex ofObject: rcvr).
			^ self fetchNextBytecode "success"].

	messageSelector _ self specialSelector: 31.
	argumentCount _ 0.
	self normalSend