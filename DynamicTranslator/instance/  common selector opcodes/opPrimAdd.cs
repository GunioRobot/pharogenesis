opPrimAdd

	| rcvr arg result |
	(self initOp: PrimAdd) ifFalse: [
	self beginOp: PrimAdd.

		rcvr _ self internalStackValue: 1.
		arg _ self internalStackValue: 0.
		(self areIntegers: rcvr and: arg) ifTrue: [
			result _ (self integerValueOf: rcvr) + (self integerValueOf: arg).
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
		self primitiveFloatAdd.
		self internalizeIPandSP.
		successFlag ifFalse: [self sendSpecialSelector: 0 nArgs: 1].

	self endOp: PrimAdd.
	]