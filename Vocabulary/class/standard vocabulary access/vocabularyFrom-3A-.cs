vocabularyFrom: aNameOrVocabulary
	"Answer the standard vocabulary of the given name, or nil if none found,  For backward compatibilitythe parameter might be an actual vocabulary, in which case return it"

	(aNameOrVocabulary isKindOf: Vocabulary) ifTrue: [^ aNameOrVocabulary].
	^ self vocabularyNamed: aNameOrVocabulary