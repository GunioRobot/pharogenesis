opExtendedPushTemporaryVariable

	(self initOp: ExtendedPushTemporaryVariable) ifFalse: [
	self beginOp: ExtendedPushTemporaryVariable.

		self pushTemporaryVariable: (self fetchInteger).
		self skip: 2.

	self endOp: ExtendedPushTemporaryVariable
	]
"
	self skip: 1.
	self pushTemporaryVariable: (currentBytecode bitAnd: 16rF).
"