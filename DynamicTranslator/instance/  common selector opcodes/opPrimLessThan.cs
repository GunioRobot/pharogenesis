opPrimLessThan

	| rcvr arg |
	(self initOp: PrimLessThan) ifFalse: [
	self beginOp: PrimLessThan.

		rcvr _ self internalStackValue: 1.
		arg _ self internalStackValue: 0.
		(self areIntegers: rcvr and: arg) ifTrue: [
			self internalPop: 2 thenPushBool: rcvr < arg.
			self skip: 1.
			^self nextOp.
		].

		self skip: 1.
		self externalizeIPandSP.
		successFlag _ true.
		self primitiveFloatLessThan.
		self internalizeIPandSP.
		successFlag ifFalse: [self sendSpecialSelector: 2 nArgs: 1].

	self endOp: PrimLessThan
	]