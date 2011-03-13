ecompletionEnabled
	^ self
		valueOfFlag: #ecompletionEnabled
		ifAbsent: [true]