convertToCurrentVersion: varDict refStream: smartRefStrm
	
	updatablePanes ifNil: [updatablePanes := #()].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

