opPushConstantZero

	(self initOp: PushConstantZero) ifFalse: [
	self beginOp: PushConstantZero.

		self internalPush: ConstZero.
		self skip: 1.

	self endOp: PushConstantZero
	]