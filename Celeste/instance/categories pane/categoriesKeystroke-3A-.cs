categoriesKeystroke: aCharacter

	aCharacter asciiValue = 30 ifTrue: [self previousCategory].
	aCharacter asciiValue = 31 ifTrue: [self nextCategory].
