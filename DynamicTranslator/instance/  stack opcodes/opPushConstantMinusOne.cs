opPushConstantMinusOne

	(self initOp: PushConstantMinusOne) ifFalse: [
	self beginOp: PushConstantMinusOne.

		self internalPush: ConstMinusOne.
		self skip: 1.

	self endOp: PushConstantMinusOne
	]