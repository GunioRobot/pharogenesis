opPushConstant

	(self initOp: PushConstant) ifFalse: [
	self beginOp: PushConstant.

		self internalPush: (self fetchLiteral).

	self endOp: PushConstant
	]