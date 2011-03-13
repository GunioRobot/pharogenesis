convertToCurrentVersion: varDict refStream: smartRefStrm
	
	lastStepTime ifNil: [lastStepTime _ 0].
	useTimeSync ifNil: [useTimeSync _ true].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.
