opReturnTopFromMethod
	(self initOp: ReturnTopFromMethod) ifFalse: [
	self beginOp: ReturnTopFromMethod.

		self skip: 1.
		self nonLocalReturn: (self internalStackTop).

	self endOp: ReturnTopFromMethod
	]