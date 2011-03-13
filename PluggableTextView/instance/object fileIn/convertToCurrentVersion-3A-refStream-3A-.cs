convertToCurrentVersion: varDict refStream: smartRefStrm
	
	hasEditingConflicts ifNil: [hasEditingConflicts := false].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

