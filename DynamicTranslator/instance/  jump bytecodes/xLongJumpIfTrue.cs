xLongJumpIfTrue
	"	101010xx		longJumpIfTrue: (xxx*256)+yyyyyyyy
		yyyyyyyy

	=>	LongJumpIfTrue
		(xxx*256)+yyyyyyyy
		nil
		nil"

	self emitOp: LongJumpIfTrue.
	self emitOffset: ((currentByte bitAnd: 3) * 256) + self nextByte.
	self emitSkip: 2.