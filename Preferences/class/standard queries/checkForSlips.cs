checkForSlips
	^ self
		valueOfFlag: #checkForSlips
		ifAbsent: [true]