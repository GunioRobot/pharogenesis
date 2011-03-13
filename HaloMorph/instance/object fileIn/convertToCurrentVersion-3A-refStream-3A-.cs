convertToCurrentVersion: varDict refStream: smartRefStrm
	
	simpleMode ifNil: [simpleMode _ false].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

