bytecodePrimDivide

	| rcvr arg result |
	rcvr _ self internalStackValue: 1.
	arg _ self internalStackValue: 0.
	(self areIntegers: rcvr and: arg) ifTrue: [
		rcvr _ self integerValueOf: rcvr.
		arg _ self integerValueOf: arg.
		((arg ~= 0) and: [(rcvr \\ arg) = 0]) ifTrue: [
			result _ rcvr // arg.  "generates C / operation"
			(self isIntegerValue: result) ifTrue: [
				self longAt: (localSP _ localSP - 4)
						put: (self integerObjectOf: result).
				^ nil
			].
		].
	].

	self externalizeIPandSP.
	successFlag _ true.
	self primitiveFloatDivide.
	successFlag ifFalse: [
		successFlag _ true.
		self primitiveDivide.
	].
	self internalizeIPandSP.
