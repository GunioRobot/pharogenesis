bytecodePrimLessOrEqual

	| rcvr arg |
	rcvr _ self internalStackValue: 1.
	arg _ self internalStackValue: 0.
	(self areIntegers: rcvr and: arg) ifTrue: [
		^ self booleanCheat: rcvr <= arg
	].

	self externalizeIPandSP.
	successFlag _ true.
	self primitiveFloatLessOrEqual.
	successFlag ifFalse: [
		successFlag _ true.
		self primitiveLessOrEqual.
	].
	self internalizeIPandSP.
