peekLiteralSelector: offset
	"Note: this won't be inlined until the conditional is removed."
	self inline: true.

	DecodeLiteralSelectors
		ifTrue: [^self peekLiteral: offset]
		ifFalse: [^self literal: (self peekInteger: offset)]