warnIfNoSourcesFile
	^ self
		valueOfFlag: #warnIfNoSourcesFile
		ifAbsent: [true]