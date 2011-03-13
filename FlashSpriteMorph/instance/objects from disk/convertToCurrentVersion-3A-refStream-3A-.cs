convertToCurrentVersion: varDict refStream: smartRefStrm
	
	lastStepTime ifNil: [lastStepTime := 0].
	useTimeSync ifNil: [useTimeSync := true].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.
