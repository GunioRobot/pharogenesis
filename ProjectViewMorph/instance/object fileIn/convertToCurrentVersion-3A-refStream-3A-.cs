convertToCurrentVersion: varDict refStream: smartRefStrm
	
	"currentBorderColor ifNil: [currentBorderColor _ Color gray]."

	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

