xPushConstantTwo

	DecodeQuickConstants
		ifTrue: [self xxPushConstant;  emitOp: PushConstant; emitLiteral: ConstTwo]
		ifFalse: [self emitOp: PushConstantTwo; emitSkip: 1]