currentVocabulary
	"Answer the currently-prevailing default vocabulary."

	^ Smalltalk isMorphic ifTrue:
			[ActiveWorld currentVocabulary]
		ifFalse:
			[Vocabulary fullVocabulary]