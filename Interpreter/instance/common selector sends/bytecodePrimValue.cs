bytecodePrimValue

	| block |
	block _ self internalStackTop.
	successFlag _ true.
	argumentCount _ 0.
	self assertClassOf: block is: (self splObj: ClassBlockContext).
	successFlag ifTrue: [
		self externalizeIPandSP.
		self primitiveValue.
		self internalizeIPandSP.
	].
	successFlag ifFalse: [
		messageSelector _ self specialSelector: 25.
		argumentCount _ 0.
		^ self normalSend
	].
