vocabularyNamed: aName
	"Answer the standard vocabulary of the given name, or nil if none found"

	^ self allStandardVocabularies at: aName asSymbol ifAbsent: []