opExperimental
	(self initOp: Experimental) ifFalse: [
	self beginOp: Experimental.

		self skip: 1.
		self error: 'Experimental opcode'.

	self endOp: Experimental
	]