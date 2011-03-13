allSelectorsInVocabulary
	"Answer a list of all selectors in the vocabulary"

	^ methodInterfaces collect: [:m | m selector]