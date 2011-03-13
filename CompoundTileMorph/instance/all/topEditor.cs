topEditor
	| editor |
	editor _ self outermostMorphThat: [:m | (m isKindOf: ScriptEditorMorph) or:
		 [m isKindOf: CompoundTileMorph]].
	^ editor ifNil: [self] ifNotNil: [editor]