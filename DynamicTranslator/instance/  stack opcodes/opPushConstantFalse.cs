opPushConstantFalse

	(self initOp: PushConstantFalse) ifFalse: [
	self beginOp: PushConstantFalse.

		self internalPush: falseObj.
		self skip: 1.

	self endOp: PushConstantFalse
	]