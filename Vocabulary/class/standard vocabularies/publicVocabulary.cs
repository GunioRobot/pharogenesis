publicVocabulary
	"Answer the public vocabulary, which admits through all non-private categories & selectors"

	^ self allVocabularies detect: [:aVocabulary | aVocabulary vocabularyName = #Public] ifNone: [self newPublicVocabulary]

	"Vocabulary publicVocabulary"