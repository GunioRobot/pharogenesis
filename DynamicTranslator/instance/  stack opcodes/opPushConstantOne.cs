opPushConstantOne

	(self initOp: PushConstantOne) ifFalse: [
	self beginOp: PushConstantOne.

		self internalPush: ConstOne.
		self skip: 1.

	self endOp: PushConstantOne
	]