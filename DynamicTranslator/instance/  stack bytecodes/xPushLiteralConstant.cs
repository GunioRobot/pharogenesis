xPushLiteralConstant
	"	001xxxxx		pushLiteralConstant: xxxxx

	=>	PushLiteralConstant
		xxxxx"
	| literal |
	DecodeLiteralConstants
		ifTrue:
			[literal _ self literal: (currentByte bitAnd: 31) ofMethod: newMethod.
			 (self isIntegerObject: literal) ifTrue: [self xxPushConstant].
			 self emitOp: PushConstant; emitLiteral: literal]
		ifFalse:
			[self emitOp: PushLiteralConstant; emitLiteralConstant: (currentByte bitAnd: 31)]