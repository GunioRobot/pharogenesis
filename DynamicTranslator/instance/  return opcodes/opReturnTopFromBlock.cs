opReturnTopFromBlock
	(self initOp: ReturnTopFromBlock) ifFalse: [
	self beginOp: ReturnTopFromBlock.

		self skip: 1.
		self localReturn: (self internalStackTop).

	self endOp: ReturnTopFromBlock
	]