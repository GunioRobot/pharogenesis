opPushLiteralConstant

	(self initOp: PushLiteralConstant) ifFalse: [
	self beginOp: PushLiteralConstant.

		self internalPush: (self fetchLiteralConstant).

	self endOp: PushLiteralConstant
	]