opDoubleExtendedPushLiteralVariable

	(self initOp: DoubleExtendedPushLiteralVariable) ifFalse: [
	self beginOp: DoubleExtendedPushLiteralVariable.

		self internalPush: (self fetchPointer: ValueIndex ofObject: self fetchLiteralVariable).
		self skip: 4.

	self endOp: DoubleExtendedPushLiteralVariable
	]