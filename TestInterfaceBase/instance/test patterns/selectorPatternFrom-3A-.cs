selectorPatternFrom: aString

	| tokens |
	tokens := aString findTokens: self classSelectorDelimiters.
	^(tokens isEmpty not and: [tokens size >= 2])
		ifFalse: [self defaultSelectorPattern]
		ifTrue: [
			| selPattern |
			selPattern := tokens at: 2.
			(self defaultSelectorPattern match: selPattern)
				ifTrue: [selPattern]
				ifFalse: [self defaultSelectorPattern]]