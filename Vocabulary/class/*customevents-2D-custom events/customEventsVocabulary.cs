customEventsVocabulary
	"Vocabulary customEventsVocabulary"
	^(self vocabularyNamed: #CustomEvents)
		ifNil: [ self addCustomEventsVocabulary ]
