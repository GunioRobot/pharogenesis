value: anObject 
	| scriptEditor |
	super value: anObject.
	(scriptEditor _ self ownerThatIsA: ScriptEditorMorph)
		ifNotNil: [scriptEditor setParameterType: anObject]