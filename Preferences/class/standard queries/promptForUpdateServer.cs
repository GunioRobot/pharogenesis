promptForUpdateServer
	^ self
		valueOfFlag: #promptForUpdateServer
		ifAbsent: [true]