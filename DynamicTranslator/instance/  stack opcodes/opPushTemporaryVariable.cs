opPushTemporaryVariable

	(self initOp: PushTemporaryVariable) ifFalse: [
	self beginOp: PushTemporaryVariable.

		self pushTemporaryVariable: (self fetchInteger).

	self endOp: PushTemporaryVariable
	]
"
	self skip: 1.
	self pushTemporaryVariable: (currentBytecode bitAnd: 16rF).
"