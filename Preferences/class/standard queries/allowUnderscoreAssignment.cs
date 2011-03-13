allowUnderscoreAssignment
	^ self
		valueOfFlag: #allowUnderscoreAssignment
		ifAbsent: [false]