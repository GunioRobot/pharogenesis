convertToCurrentVersion: varDict refStream: smartRefStrm
	
	cachingEnabled ifNil: [cachingEnabled _ true].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.
