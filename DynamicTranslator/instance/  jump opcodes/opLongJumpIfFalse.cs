opLongJumpIfFalse

	| offset |
	(self initOp: LongJumpIfFalse) ifFalse: [
	self beginOp: LongJumpIfFalse.

		offset _ self fetchOffset.
		self skip: 2.
		self jumpIfFalseBy: offset.

	self endOp: LongJumpIfFalse
	]