fullyImplementsVocabulary: aVocabulary
	"Answer whether instances of the receiver respond to all the messages in aVocabulary"

	(aVocabulary encompassesAPriori: self) ifTrue: [^ true].
	aVocabulary allSelectorsInVocabulary do:
		[:aSelector | (self canUnderstand: aSelector) ifFalse: [^ false]].
	^ true