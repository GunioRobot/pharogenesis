xPushConstantMinusOne

	DecodeQuickConstants
		ifTrue: [self xxPushConstant;  emitOp: PushConstant;  emitLiteral: ConstMinusOne]
		ifFalse: [self emitOp: PushConstantMinusOne;  emitSkip: 1]