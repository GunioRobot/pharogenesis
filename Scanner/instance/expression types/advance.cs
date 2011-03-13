advance

	| prevToken |
	prevToken _ token.
	self scanToken.
	^prevToken