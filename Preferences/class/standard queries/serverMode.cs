serverMode
	^ self
		valueOfFlag: #serverMode
		ifAbsent: [true]