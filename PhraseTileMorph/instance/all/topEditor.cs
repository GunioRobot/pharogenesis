topEditor
	^ self outermostMorphThat: [:m | (m isKindOf: ScriptEditorMorph) or:
		 [m isKindOf: CompoundTileMorph]]