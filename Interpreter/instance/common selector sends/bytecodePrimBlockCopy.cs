bytecodePrimBlockCopy

	| rcvr hdr |
	rcvr _ self internalStackValue: 1.
	successFlag _ true.
	hdr _ self baseHeader: rcvr.
	self success: (self isContextHeader: hdr).
	successFlag ifTrue: [self externalizeIPandSP.
		self primitiveBlockCopy.
		self internalizeIPandSP].
	successFlag ifFalse: [messageSelector _ self specialSelector: 24.
		argumentCount _ 1.
		^ self normalSend].
	self fetchNextBytecode.
