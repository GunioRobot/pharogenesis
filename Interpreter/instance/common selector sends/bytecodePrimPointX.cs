bytecodePrimPointX

	successFlag _ true.
	self externalizeIPandSP.
	self primitivePointX.
	self internalizeIPandSP.
	successFlag ifTrue: [^ self fetchNextBytecode "success"].

	messageSelector _ self specialSelector: 30.
	argumentCount _ 0.
	self normalSend