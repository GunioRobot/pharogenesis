opPrimNotEqual

	| rcvr arg |
	(self initOp: PrimNotEqual) ifFalse: [
	self beginOp: PrimNotEqual.

		rcvr _ self internalStackValue: 1.
		arg _ self internalStackValue: 0.
		(self areIntegers: rcvr and: arg) ifTrue: [
			self internalPop: 2 thenPushBool: rcvr ~= arg.
			self skip: 1.
			^self nextOp.
		].

		self skip: 1.
		self externalizeIPandSP.
		successFlag _ true.
		self primitiveFloatNotEqual.
		self internalizeIPandSP.
		successFlag ifFalse: [self sendSpecialSelector: 7 nArgs: 1].

	self endOp: PrimNotEqual
	]