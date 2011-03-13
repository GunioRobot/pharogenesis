updateFromServerAtStartup
	^ self
		valueOfFlag: #updateFromServerAtStartup
		ifAbsent: [false]