bytecodePrimBitOr

	successFlag _ true.
	self externalizeIPandSP.
	self primitiveBitOr.
	self internalizeIPandSP.
	successFlag ifTrue: [^ self fetchNextBytecode "success"].

	messageSelector _ self specialSelector: 15.
	argumentCount _ 1.
	self normalSend