xPushConstantNil

	DecodeQuickConstants
		ifTrue: [self emitOp: PushConstant; emitLiteral: nilObj]
		ifFalse: [self emitOp: PushConstantNil; emitSkip: 1]