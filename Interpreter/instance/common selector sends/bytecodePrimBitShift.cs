bytecodePrimBitShift

	successFlag _ true.
	self externalizeIPandSP.
	self primitiveBitShift.
	self internalizeIPandSP.
	successFlag ifTrue: [^ self fetchNextBytecode "success"].

	messageSelector _ self specialSelector: 12.
	argumentCount _ 1.
	self normalSend