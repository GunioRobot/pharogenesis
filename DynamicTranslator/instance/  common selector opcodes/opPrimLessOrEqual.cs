opPrimLessOrEqual

	| rcvr arg |
	(self initOp: PrimLessOrEqual) ifFalse: [
	self beginOp: PrimLessOrEqual.

		rcvr _ self internalStackValue: 1.
		arg _ self internalStackValue: 0.
		(self areIntegers: rcvr and: arg) ifTrue: [
			self internalPop: 2 thenPushBool: rcvr <= arg.
			self skip: 1.
			^self nextOp.
		].

		self skip: 1.
		self externalizeIPandSP.
		successFlag _ true.
		self primitiveFloatLessOrEqual.
		self internalizeIPandSP.
		successFlag ifFalse: [self sendSpecialSelector: 4 nArgs: 1].

	self endOp: PrimLessOrEqual
	]