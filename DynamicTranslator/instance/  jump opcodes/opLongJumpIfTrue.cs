opLongJumpIfTrue

	| offset |
	(self initOp: LongJumpIfTrue) ifFalse: [
	self beginOp: LongJumpIfTrue.

		offset _ self fetchOffset.
		self skip: 2.
		self jumpIfTrueBy: offset.

	self endOp: LongJumpIfTrue
	]