advance

	| prevToken |
	prevToken := token.
	self scanToken.
	^prevToken