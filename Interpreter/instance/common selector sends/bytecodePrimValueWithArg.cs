bytecodePrimValueWithArg

	| block |
	block _ self internalStackValue: 1.
	successFlag _ true.
	argumentCount _ 1.
	self assertClassOf: block is: (self splObj: ClassBlockContext).
	successFlag ifTrue: [
		self externalizeIPandSP.
		self primitiveValue.
		self internalizeIPandSP.
	].
	successFlag ifFalse: [
		messageSelector _ self specialSelector: 26.
		argumentCount _ 1.
		^ self normalSend
	].
