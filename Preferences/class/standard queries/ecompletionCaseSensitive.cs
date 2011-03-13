ecompletionCaseSensitive
	^ self
		valueOfFlag: #ecompletionCaseSensitive
		ifAbsent: [true]