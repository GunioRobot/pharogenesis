xPushConstantTrue

	DecodeQuickConstants
		ifTrue: [self emitOp: PushConstant; emitLiteral: trueObj]
		ifFalse: [self emitOp: PushConstantTrue; emitSkip: 1]