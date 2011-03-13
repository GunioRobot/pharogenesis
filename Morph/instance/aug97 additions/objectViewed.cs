objectViewed
	^ (self outermostMorphThat: [:o | o isKindOf: PartsViewer orOf: ScriptEditorMorph])  morph