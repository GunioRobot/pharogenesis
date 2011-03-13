addVocabulary: aVocabulary
	"Add a vocabulary to the list of standard vocabularies"

	self allVocabularies.  "Assures initialization"
	AllVocabularies add: aVocabulary