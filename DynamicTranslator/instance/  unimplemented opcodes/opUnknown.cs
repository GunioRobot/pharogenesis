opUnknown
	(self initOp: Unknown) ifFalse: [
	self beginOp: Unknown.

		self skip: 1.
		self error: 'Unknown opcode'.

	self endOp: Unknown
	]