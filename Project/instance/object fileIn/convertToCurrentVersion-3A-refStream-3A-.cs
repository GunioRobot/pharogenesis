convertToCurrentVersion: varDict refStream: smartRefStrm
	
	isolatedHead ifNil: [isolatedHead _ false].
	inForce ifNil: [inForce _ false].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

