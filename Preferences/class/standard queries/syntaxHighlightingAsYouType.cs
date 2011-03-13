syntaxHighlightingAsYouType
	^ self
		valueOfFlag: #syntaxHighlightingAsYouType
		ifAbsent: [true]