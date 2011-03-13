eToyVocabulary
	"Anser the etoy vocabulary, if one exists in the AllVocabularies list"

	^ self allVocabularies detect: [:aVocabulary | aVocabulary vocabularyName == #eToy] ifNone: [nil]