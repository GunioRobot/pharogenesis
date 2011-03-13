convertToCurrentVersion: varDict refStream: smartRefStrm
	
	varDict at: 'responseUponCancel' ifAbsent: [responseUponCancel _ ''].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

