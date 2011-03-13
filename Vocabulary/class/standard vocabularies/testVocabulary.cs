testVocabulary
	"Answer the Test vocabulary lurking in my AllVocabularies list"

	^ self allVocabularies detect: [:aVocabulary | aVocabulary vocabularyName == #Test] ifNone: [nil]