findClassIn: anEnvironment pattern: pattern
	| classNames className toMatch potentialClassNames |
	toMatch := (pattern copyWithout: $.) asLowercase.
	potentialClassNames := (anEnvironment classNames , anEnvironment traitNames) asArray.
	classNames := (pattern endsWith: '.')
					ifTrue: [potentialClassNames
							select: [:nm | nm asLowercase = toMatch]]
					ifFalse: [potentialClassNames
							select: [:n | n includesSubstring: toMatch caseSensitive: false]].
	classNames size = 0 ifTrue: [^ nil].
	classNames size = 1 ifTrue: [^ anEnvironment at: classNames first asSymbol].
	className := self userSelectionOf: classNames for: toMatch.
	^ className ifNotNil: [anEnvironment at: className asSymbol]
