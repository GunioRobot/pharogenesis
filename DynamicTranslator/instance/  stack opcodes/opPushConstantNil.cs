opPushConstantNil

	(self initOp: PushConstantNil) ifFalse: [
	self beginOp: PushConstantNil.

		self internalPush: nilObj.
		self skip: 1.

	self endOp: PushConstantNil
	]