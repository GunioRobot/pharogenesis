opReturnReceiver
	(self initOp: ReturnReceiver) ifFalse: [
	self beginOp: ReturnReceiver.

		self skip: 1.
		self nonLocalReturn: self internalReceiver.

	self endOp: ReturnReceiver
	]