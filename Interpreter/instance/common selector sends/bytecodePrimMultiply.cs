bytecodePrimMultiply

	| rcvr arg result |
	rcvr _ self internalStackValue: 1.
	arg _ self internalStackValue: 0.
	(self areIntegers: rcvr and: arg) ifTrue: [
		rcvr _ self integerValueOf: rcvr.
		arg _ self integerValueOf: arg.
		result _ rcvr * arg.
		((arg = 0 or: [(result // arg) = rcvr]) and:
		 [self isIntegerValue: result]) ifTrue: [
			self longAt: (localSP _ localSP - 4)
					put: (self integerObjectOf: result).
			^ nil
		].
	].

	self externalizeIPandSP.
	successFlag _ true.
	self primitiveFloatMultiply.
	successFlag ifFalse: [
		successFlag _ true.
		self primitiveMultiply.
	].
	self internalizeIPandSP.
