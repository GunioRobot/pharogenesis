typeChoices
	"Answer a list of all user-choosable data types"

	^ (self allStandardVocabularies
		select:
			[:aVocab | aVocab representsAType]
		thenCollect:
			[:aVocab | aVocab vocabularyName]) asSortedArray
