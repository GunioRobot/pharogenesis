debugLogTimestamp
	^ self
		valueOfFlag: #debugLogTimestamp
		ifAbsent: [false]