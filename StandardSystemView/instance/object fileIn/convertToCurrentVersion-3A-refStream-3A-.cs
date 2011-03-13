convertToCurrentVersion: varDict refStream: smartRefStrm
	
	updatablePanes ifNil: [updatablePanes _ #()].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

