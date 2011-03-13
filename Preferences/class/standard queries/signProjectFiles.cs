signProjectFiles
	^ self
		valueOfFlag: #signProjectFiles
		ifAbsent: [true]