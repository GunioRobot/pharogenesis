vocabularyForType: aType
	"Answer a vocabulary appropriate to the given type, which is normally going to be a symbol such as #Number or #Color.  Answer the Unknown vocabulary as a fall-back"

	| ucSym |
	(aType isKindOf: Vocabulary) ifTrue: [^ aType].
	ucSym _ aType capitalized asSymbol.
	^self allStandardVocabularies at: ucSym ifAbsent: [self vocabularyNamed: #unknown]