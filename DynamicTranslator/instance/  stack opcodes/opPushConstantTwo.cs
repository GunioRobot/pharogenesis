opPushConstantTwo

	(self initOp: PushConstantTwo) ifFalse: [
	self beginOp: PushConstantTwo.

		self internalPush: ConstTwo.
		self skip: 1.

	self endOp: PushConstantTwo
	]