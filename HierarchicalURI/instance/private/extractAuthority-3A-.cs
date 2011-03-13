extractAuthority: aString
	| endAuthorityIndex authorityString |
	endAuthorityIndex _ (aString indexOf: $/ ) - 1.
	endAuthorityIndex < 0
		ifTrue: [endAuthorityIndex _ aString size].
	authorityString _ aString copyFrom: 1 to: endAuthorityIndex.
	authority _ URIAuthority fromString: authorityString.
	^aString copyFrom: endAuthorityIndex+1 to: aString size