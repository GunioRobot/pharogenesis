opDoubleExtendedPushConstant

	(self initOp: DoubleExtendedPushConstant) ifFalse: [
	self beginOp: DoubleExtendedPushConstant.

		self internalPush: self fetchLiteralConstant.
		self skip: 4.

	self endOp: DoubleExtendedPushConstant
	]