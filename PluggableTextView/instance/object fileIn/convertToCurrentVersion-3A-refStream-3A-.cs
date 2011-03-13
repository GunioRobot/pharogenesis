convertToCurrentVersion: varDict refStream: smartRefStrm
	
	hasEditingConflicts ifNil: [hasEditingConflicts _ false].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

