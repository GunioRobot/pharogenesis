opShortUnconditionalJump
	| offset |
	(self initOp: ShortUnconditionalJump) ifFalse: [
	self beginOp: ShortUnconditionalJump.

		offset _ self fetchOffset.		"must be broken into two for inlining"
		self jump: offset.

	self endOp: ShortUnconditionalJump
	]