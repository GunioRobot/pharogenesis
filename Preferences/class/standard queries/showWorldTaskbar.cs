showWorldTaskbar
	^ self
		valueOfFlag: #showWorldTaskbar
		ifAbsent: [true]