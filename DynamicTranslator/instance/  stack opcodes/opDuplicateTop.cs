opDuplicateTop

	(self initOp: DuplicateTop) ifFalse: [
	self beginOp: DuplicateTop.

		self internalPush: self internalStackTop.
		self skip: 1.

	self endOp: DuplicateTop
	]