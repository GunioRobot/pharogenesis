currentVocabulary
	"Answer the current vocabulary"

	vocabulary "fix up old strutures"
		ifNotNil: 
			[vocabularySymbol _ vocabulary vocabularyName.
			vocabulary _ nil].

	^ vocabularySymbol
		ifNotNil:
			[Vocabulary vocabularyNamed: vocabularySymbol]
		ifNil:
			[super currentVocabulary]
