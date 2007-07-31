serverMode
	^ self
		valueOfFlag: #serverMode
		ifAbsent: [false]