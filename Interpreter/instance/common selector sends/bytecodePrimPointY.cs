bytecodePrimPointY

	successFlag _ true.
	self externalizeIPandSP.
	self primitivePointY.
	self internalizeIPandSP.
	successFlag ifTrue: [^ self fetchNextBytecode "success"].

	messageSelector _ self specialSelector: 31.
	argumentCount _ 0.
	self normalSend