objectViewed
	^ (self outermostMorphThat: [:o | o isKindOf: Viewer orOf: ScriptEditorMorph]) objectViewed