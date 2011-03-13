maintainHalos
	^ self
		valueOfFlag: #maintainHalos
		ifAbsent: [true]