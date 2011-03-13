cautionBeforeClosing
	^ self
		valueOfFlag: #cautionBeforeClosing
		ifAbsent: [false]