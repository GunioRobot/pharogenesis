opReturnConstant
	(self initOp: ReturnConstant) ifFalse: [
	self beginOp: ReturnConstant.

		self nonLocalReturn: (self fetchLiteral).

	self endOp: ReturnConstant
	]