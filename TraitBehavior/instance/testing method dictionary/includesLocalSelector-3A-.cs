includesLocalSelector: aSymbol
	^self basicLocalSelectors isNil
		ifTrue: [self includesSelector: aSymbol]
		ifFalse: [self localSelectors includes: aSymbol]