hasUnacceptedEdits: aBoolean
	super hasUnacceptedEdits: aBoolean.
	aBoolean ifFalse: [hasEditingConflicts := false]