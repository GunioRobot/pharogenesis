testVocabulary
	"Answer the Test vocabulary lurking in my AllStandardVocabularies list, creating it if necessary"
	"Vocabulary testVocabulary"

	^ self allStandardVocabularies at: #Test ifAbsentPut: [self newTestVocabulary]