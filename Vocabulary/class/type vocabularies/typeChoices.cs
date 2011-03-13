typeChoices
	"Answer a list of all user-choosable data types"

	| aList |
	(aList _ self allStandardVocabularies
		select:
			[:aVocab | aVocab representsAType]
		thenCollect:
			[:aVocab | aVocab vocabularyName]).
	Preferences allowEtoyUserCustomEvents ifFalse: [aList remove: #CustomEvents ifAbsent: []].
	^ aList asSortedArray