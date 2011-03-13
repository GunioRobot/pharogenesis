allVocabularies
	"Answer a list of the currently-defined vocabularies in my AllVocabularies list"

	^ (AllVocabularies ifNil: [AllVocabularies _ self initializeStandardVocabularies]) copy