restartAlsoProceeds
	^ self
		valueOfFlag: #restartAlsoProceeds
		ifAbsent: [true]