opPopStack

	(self initOp: PopStack) ifFalse: [
	self beginOp: PopStack.

		self internalPop: 1.
		self skip: 1.

	self endOp: PopStack
	]