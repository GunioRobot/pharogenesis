fetchLiteralConstant
	"Note: this won't be inlined until the conditional is removed."
	self inline: true.

	DecodeLiteralConstants
		ifTrue: [^self fetchLiteral]
		ifFalse: [^self literal: self fetchInteger]