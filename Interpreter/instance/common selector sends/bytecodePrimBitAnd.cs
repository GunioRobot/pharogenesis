bytecodePrimBitAnd

	successFlag _ true.
	self externalizeIPandSP.
	self primitiveBitAnd.
	self internalizeIPandSP.
	successFlag ifTrue: [^ self fetchNextBytecode "success"].

	messageSelector _ self specialSelector: 14.
	argumentCount _ 1.
	self normalSend