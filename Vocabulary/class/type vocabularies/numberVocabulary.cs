numberVocabulary
	"Answer the standard vocabulary representing numbers, creating it if necessary"

	^self allStandardVocabularies at: #Number ifAbsentPut: [self newNumberVocabulary]