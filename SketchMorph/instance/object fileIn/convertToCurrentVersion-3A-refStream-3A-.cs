convertToCurrentVersion: varDict refStream: smartRefStrm
	
	scalePoint ifNil: [scalePoint _ 1.0@1.0].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

