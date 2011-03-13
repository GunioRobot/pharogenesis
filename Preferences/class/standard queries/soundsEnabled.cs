soundsEnabled
	^ self
		valueOfFlag: #soundsEnabled
		ifAbsent: [true]