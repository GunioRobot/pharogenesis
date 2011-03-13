addCustomEventsVocabulary
	| vocab |
	self addStandardVocabulary: (vocab := self newCustomEventsVocabulary).
	SymbolListTile updateAllTilesForVocabularyNamed: #CustomEvents.
	^vocab