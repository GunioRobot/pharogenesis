xPushConstantZero

	DecodeQuickConstants
		ifTrue: [self xxPushConstant;  emitOp: PushConstant;  emitLiteral: ConstZero]
		ifFalse: [self emitOp: PushConstantZero;  emitSkip: 1]