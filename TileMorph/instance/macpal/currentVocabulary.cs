currentVocabulary
	"Answer the receiver's current vocabulary"

	| outer aVocab |
	vocabulary ifNotNil:  "old structures -- bring up to date"
		[vocabularySymbol _ vocabulary vocabularyName.
		vocabulary _ nil].
	^ vocabularySymbol
		ifNotNil:
			[Vocabulary vocabularyNamed: vocabularySymbol]
		ifNil:
			[(outer _ self ownerThatIsA: StandardViewer orA: ScriptEditorMorph) 
				ifNotNil:
					[aVocab _ outer currentVocabulary.
					vocabularySymbol _ aVocab vocabularyName.
					aVocab]
				ifNil:
					[super currentVocabulary]]