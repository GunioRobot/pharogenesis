oliveHandleForScriptedObjects
	^ self
		valueOfFlag: #oliveHandleForScriptedObjects
		ifAbsent: [true]