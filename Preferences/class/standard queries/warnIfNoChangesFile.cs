warnIfNoChangesFile
	^ self
		valueOfFlag: #warnIfNoChangesFile
		ifAbsent: [true]