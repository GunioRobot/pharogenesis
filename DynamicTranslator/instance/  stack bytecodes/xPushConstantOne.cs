xPushConstantOne

	DecodeQuickConstants
		ifTrue: [self xxPushConstant;  emitOp: PushConstant; emitLiteral: ConstOne]
		ifFalse: [self emitOp: PushConstantOne; emitSkip: 1]