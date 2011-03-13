logDebuggerStackToFile
	^ self
		valueOfFlag: #logDebuggerStackToFile
		ifAbsent: [true]