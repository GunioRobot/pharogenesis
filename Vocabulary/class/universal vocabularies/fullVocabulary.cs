fullVocabulary
	"Answer the full vocabulary in my AllStandardVocabularies list, creating it if necessary"

	^ self allStandardVocabularies at: #Full ifAbsentPut: [FullVocabulary new]