opPrimEqual

	| rcvr arg |
	(self initOp: PrimEqual) ifFalse: [
	self beginOp: PrimEqual.

		rcvr _ self internalStackValue: 1.
		arg _ self internalStackValue: 0.
		(self areIntegers: rcvr and: arg) ifTrue: [
			self internalPop: 2 thenPushBool: rcvr = arg.
			self skip: 1.
			^self nextOp.
		].

		self skip: 1.
		self externalizeIPandSP.
		successFlag _ true.
		self primitiveFloatEqual.
		self internalizeIPandSP.
		successFlag ifFalse: [self sendSpecialSelector: 6 nArgs: 1].

	self endOp: PrimEqual
	]