wordingSelector: aSelector
	wordingSelector _ aSelector.
	wordingProvider ifNil: [wordingProvider _ target]