convertToCurrentVersion: varDict refStream: smartRefStrm
	
	borderWidth ifNil:
		[borderWidth _ 0.
		self removeProperty: #fillStyle].
	^ super convertToCurrentVersion: varDict refStream: smartRefStrm.

