xShortUnconditionalJump
	"	10010xxx		shortUnconditionalJump: xxx

	=>	ShortUnconditionalJump
		xxx"

	self emitOp: ShortUnconditionalJump.
	self emitOffset: (currentByte bitAnd: 7) + 1.

"
	self emitBytecode.
	self emitSkip: 1.
"