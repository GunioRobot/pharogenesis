next
	| ans |
	cachedToken ifNil: [ ^self nextToken ].
	ans _ cachedToken.
	cachedToken _ nil.
	^ans