currentVocabulary
	"Answer the receiver's current vocabulary"

	| outer |
	^ (outer _ self ownerThatIsA: StandardViewer orA: ScriptEditorMorph) 
			ifNotNil:
				[outer currentVocabulary]
			ifNil:
				[super currentVocabulary]