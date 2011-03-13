convertToCurrentVersion: varDict refStream: smartRefStrm
	
	timeOfLastListUpdate ifNil: [timeOfLastListUpdate _ 0].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

