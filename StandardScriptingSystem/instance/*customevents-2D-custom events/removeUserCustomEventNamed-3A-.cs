removeUserCustomEventNamed: eventName
	| retval |
	retval _ self currentWorld removeUserCustomEventNamed: eventName.
	"Vocabulary addStandardVocabulary: UserCustomEventNameType new."
	Vocabulary customEventsVocabulary.
	SymbolListTile updateAllTilesForVocabularyNamed: #CustomEvents.
	^retval