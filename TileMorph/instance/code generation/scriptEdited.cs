scriptEdited
	"Tell the scriptEditor who I belong to that I have changed.  "
	| him |
	(him _ self outermostMorphThat: [:m| m isKindOf: ScriptEditorMorph])
		ifNotNil: [him scriptEdited]