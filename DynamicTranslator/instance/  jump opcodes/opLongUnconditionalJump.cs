opLongUnconditionalJump
	"LongUnconditionalJump
	signedOffset
	nil
	nil"

	| offset |
	(self initOp: LongUnconditionalJump) ifFalse: [
	self beginOp: LongUnconditionalJump.

		offset _ self fetchOffset.
		self skip: 2.
		self jump: offset.

	self endOp: LongUnconditionalJump
	]