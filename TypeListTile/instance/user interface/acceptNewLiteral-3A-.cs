acceptNewLiteral: aLiteral
	"Accept the new literal"

	| scriptEditor |
	super acceptNewLiteral: aLiteral.
	(scriptEditor _ self ownerThatIsA: ScriptEditorMorph) ifNotNil:
			[scriptEditor setParameterType: aLiteral asSymbol]