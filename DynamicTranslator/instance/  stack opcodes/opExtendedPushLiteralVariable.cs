opExtendedPushLiteralVariable

	(self initOp: ExtendedPushLiteralVariable) ifFalse: [
	self beginOp: ExtendedPushLiteralVariable.

		self internalPush: (self fetchPointer: ValueIndex ofObject: (self fetchLiteralVariable)).
		self skip: 2.

	self endOp: ExtendedPushLiteralVariable
	]