categoryFromDoIt: aString
	| tokens  |
	tokens _ Scanner new scanTokens: aString.
	tokens size = 3 ifFalse: [self error: 'Unrecognized category definition'].
	^ tokens at: 3