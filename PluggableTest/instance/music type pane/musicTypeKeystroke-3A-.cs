musicTypeKeystroke: aCharacter

	musicTypeList doWithIndex: [:type :i |
		(type first asLowercase = aCharacter asLowercase)
			ifTrue: [self musicType: i]].
