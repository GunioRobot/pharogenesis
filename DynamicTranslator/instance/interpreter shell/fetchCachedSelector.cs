fetchCachedSelector
	self inline: true.

	DecodeLiteralSelectors
		ifTrue: [^self fetchLiteral]
		ifFalse: [^self literal: self fetchInteger]