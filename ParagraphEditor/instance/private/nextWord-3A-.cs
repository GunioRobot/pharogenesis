nextWord: position
	| string index |
	string _ paragraph text string.
	index _ position.
	[(index between: 1 and: string size) and: [(string at: index) isAlphaNumeric]]
		whileTrue: [index _ index + 1].
	[(index between: 1 and: string size) and: [(string at: index) isAlphaNumeric not]]
		whileTrue: [index _ index + 1].
	^ index