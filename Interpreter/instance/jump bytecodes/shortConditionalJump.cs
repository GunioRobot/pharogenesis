shortConditionalJump

	self jumplfFalseBy: (currentBytecode bitAnd: 7) + 1.