opShortConditionalJump
	| offset |
	(self initOp: ShortConditionalJump) ifFalse: [
	self beginOp: ShortConditionalJump.

		offset _ self fetchOffset.		"must be broken into two for inlining"
		self jumpIfFalseBy: offset.

	self endOp: ShortConditionalJump
	]