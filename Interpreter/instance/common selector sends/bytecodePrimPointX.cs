bytecodePrimPointX

	| rcvr |
	successFlag _ true.
	rcvr _ self internalStackTop.
	self assertClassOf: rcvr is: (self splObj: ClassPoint).
	successFlag
		ifTrue: [self internalPop: 1 thenPush: (self fetchPointer: XIndex ofObject: rcvr).
			^ self fetchNextBytecode "success"].

	messageSelector _ self specialSelector: 30.
	argumentCount _ 0.
	self normalSend