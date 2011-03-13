convertToCurrentVersion: varDict refStream: smartRefStrm
	
	hasChanged ifNil: [hasChanged _ false].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

