opPrimSubtract

	| rcvr arg result |
	(self initOp: PrimSubtract) ifFalse: [
	self beginOp: PrimSubtract.

		rcvr _ self internalStackValue: 1.
		arg _ self internalStackValue: 0.
		(self areIntegers: rcvr and: arg) ifTrue: [
			result _ (self integerValueOf: rcvr) - (self integerValueOf: arg).
			(self isIntegerValue: result) ifTrue: [
				self longAt: (localSP _ localSP - 4)
						put: (self integerObjectOf: result).
				self skip: 1.
				^self nextOp.
			].
		].

		self skip: 1.
		self externalizeIPandSP.
		successFlag _ true.
		self primitiveFloatSubtract.
		self internalizeIPandSP.
		successFlag ifFalse: [self sendSpecialSelector: 1 nArgs: 1].

	self endOp: PrimSubtract
	]
