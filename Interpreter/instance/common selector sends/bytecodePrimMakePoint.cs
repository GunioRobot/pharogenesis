bytecodePrimMakePoint

	successFlag _ true.
	self externalizeIPandSP.
	self primitiveMakePoint.
	self internalizeIPandSP.
	successFlag ifTrue: [^ self fetchNextBytecode "success"].

	messageSelector _ self specialSelector: 11.
	argumentCount _ 1.
	self normalSend