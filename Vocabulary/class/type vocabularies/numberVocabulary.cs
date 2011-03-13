numberVocabulary
	"Answer the standard vocabulary representing numbers"

	^ self allVocabularies detect: [:aVocabulary | aVocabulary vocabularyName == #number] ifNone: [nil]