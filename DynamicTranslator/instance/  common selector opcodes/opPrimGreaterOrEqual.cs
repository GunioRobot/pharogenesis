opPrimGreaterOrEqual

	| rcvr arg |
	(self initOp: PrimGreaterOrEqual) ifFalse: [
	self beginOp: PrimGreaterOrEqual.

		rcvr _ self internalStackValue: 1.
		arg _ self internalStackValue: 0.
		(self areIntegers: rcvr and: arg) ifTrue: [
			self internalPop: 2 thenPushBool: rcvr >= arg.
			self skip: 1.
			^self nextOp.
		].

		self skip: 1.
		self externalizeIPandSP.
		successFlag _ true.
		self primitiveFloatGreaterOrEqual.
		self internalizeIPandSP.
		successFlag ifFalse: [self sendSpecialSelector: 5 nArgs: 1].

	self endOp: PrimGreaterOrEqual
	]