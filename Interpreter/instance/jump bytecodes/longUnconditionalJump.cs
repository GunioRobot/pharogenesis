longUnconditionalJump

	| offset |
	offset _ (((currentBytecode bitAnd: 7) - 4) * 256) + self fetchByte.
	localIP _ localIP + offset.
	offset < 0 ifTrue: [
		"backward jump means we're in a loop; check for possible interrupts"
		self internalQuickCheckForInterrupts.
	].