bytecodePrimSubtract

	| rcvr arg result |
	rcvr _ self internalStackValue: 1.
	arg _ self internalStackValue: 0.
	(self areIntegers: rcvr and: arg) ifTrue: [
		result _ (self integerValueOf: rcvr) - (self integerValueOf: arg).
		(self isIntegerValue: result) ifTrue: [
			self longAt: (localSP _ localSP - 4)
					put: (self integerObjectOf: result).
			^ nil
		].
	].

	self externalizeIPandSP.
	successFlag _ true.
	self primitiveFloatSubtract.
	successFlag ifFalse: [
		successFlag _ true.
		self primitiveSubtract.
	].
	self internalizeIPandSP.
