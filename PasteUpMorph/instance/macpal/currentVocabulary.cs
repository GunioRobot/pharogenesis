currentVocabulary
	"Answer the default Vocabulary object to be applied when scripting"

	| aSym aVocab |
	aSym _ self valueOfProperty: #currentVocabularySymbol.
	aSym ifNil:
		[aVocab _ self valueOfProperty: #currentVocabulary.
		aVocab ifNotNil:
			[aSym _ aVocab vocabularyName.
			self setProperty: #currentVocabularySymbol toValue: aSym.
			self removeProperty: #currentVocabulary]].
	^ aSym
		ifNotNil:
			[Vocabulary vocabularyNamed: aSym]
		ifNil:
			[Vocabulary fullVocabulary]