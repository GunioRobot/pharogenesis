convertToCurrentVersion: varDict refStream: smartRefStrm
	
	varDict at: 'responseUponCancel' ifAbsent: [responseUponCancel := ''].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

