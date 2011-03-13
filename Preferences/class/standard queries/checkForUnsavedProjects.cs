checkForUnsavedProjects
	^ self
		valueOfFlag: #checkForUnsavedProjects
		ifAbsent: [true]