convertToCurrentVersion: varDict refStream: smartRefStrm
	
	acceptDroppedMorphs ifNil: [acceptDroppedMorphs _ false].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

