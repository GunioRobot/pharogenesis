xPushConstantFalse

	DecodeQuickConstants
		ifTrue: [self emitOp: PushConstant; emitLiteral: falseObj]
		ifFalse: [self emitOp: PushConstantFalse; emitSkip: 1]