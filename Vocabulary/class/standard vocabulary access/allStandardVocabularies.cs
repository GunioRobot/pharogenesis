allStandardVocabularies
	"Answer a list of the currently-defined vocabularies in my AllStandardVocabularies list"
	"Vocabulary allStandardVocabularies"

	^AllStandardVocabularies ifNil: [AllStandardVocabularies _ IdentityDictionary new].

