mvcProjectsAllowed
	^ self
		valueOfFlag: #mvcProjectsAllowed
		ifAbsent: [true]