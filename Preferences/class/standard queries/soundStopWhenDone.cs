soundStopWhenDone
	^ self
		valueOfFlag: #soundStopWhenDone
		ifAbsent: [false]