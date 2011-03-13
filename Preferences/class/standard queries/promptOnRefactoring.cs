promptOnRefactoring
	^ self
		valueOfFlag: #promptOnRefactoring
		ifAbsent: [true]