storeAndPopTemporaryVariableBytecode

	self storePointerUnchecked: (currentBytecode bitAnd: 7) + TempFrameStart
		ofObject: theHomeContext
		withValue: self internalStackTop.
	self internalPop: 1.
