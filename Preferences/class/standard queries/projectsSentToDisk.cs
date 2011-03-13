projectsSentToDisk
	^ self
		valueOfFlag: #projectsSentToDisk
		ifAbsent: [false]