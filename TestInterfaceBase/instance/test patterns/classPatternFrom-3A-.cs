classPatternFrom: aString

	| tokens |
	tokens := aString findTokens: self classSelectorDelimiters.
	^tokens isEmpty
		ifTrue: [self defaultClassPattern]
		ifFalse: [
			| newClassPattern |
			newClassPattern := tokens first.
			(self matchingClassesForPattern: newClassPattern) isEmpty
				ifFalse: [newClassPattern]
				ifTrue: [self defaultClassPattern]]