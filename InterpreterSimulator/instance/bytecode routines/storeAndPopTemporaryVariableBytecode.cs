storeAndPopTemporaryVariableBytecode

	"Interpreter version has fetchNextBytecode out of order"
	self storePointerUnchecked: (currentBytecode bitAnd: 7) + TempFrameStart
		ofObject: localHomeContext
		withValue: self internalStackTop.
	self internalPop: 1.
	self fetchNextBytecode.
