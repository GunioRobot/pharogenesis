adoptVocabulary: aVocabulary
	"Set the receiver's vocabulary"

	vocabularySymbol _ aVocabulary vocabularyName.
	self updateWordingToMatchVocabulary.
	super adoptVocabulary: aVocabulary