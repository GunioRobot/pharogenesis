decodeLiteralSelector: litSel
	"Note: this won't be inlined until the conditional is removed."
	self inline: true.

	DecodeLiteralSelectors
		ifTrue: [^litSel]
		ifFalse: [^self literal: (self integerValueOf: litSel)]