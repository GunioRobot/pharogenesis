opExtendedPushConstant

	(self initOp: ExtendedPushConstant) ifFalse: [
	self beginOp: ExtendedPushConstant.

		self internalPush: (self fetchLiteralConstant).
		self skip: 2.

	self endOp: ExtendedPushConstant
	]