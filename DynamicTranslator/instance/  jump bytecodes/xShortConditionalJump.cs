xShortConditionalJump
	"	10011xxx		shortConditionalJump: xxx

	=>	ShortConditionalJump
		xxx"

	self emitOp: ShortConditionalJump.
	self emitOffset: (currentByte bitAnd: 7) + 1.
"
	self emitBytecode.
	self emitSkip: 1.
"