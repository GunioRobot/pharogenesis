convertToCurrentVersion: varDict refStream: smartRefStrm
	
	smoothCurve ifNil: [smoothCurve _ false].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

