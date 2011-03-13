allScriptEditors
	^ self allMorphs select:
		[:s | s isKindOf: ScriptEditorMorph]