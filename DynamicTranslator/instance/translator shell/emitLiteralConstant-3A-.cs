emitLiteralConstant: index
	"Note: this won't be inlined until the conditional is removed."

	DecodeLiteralConstants
		ifTrue: [self emitLiteral: (self literal: index ofMethod: newMethod)]
		ifFalse: [self emitInteger: index]