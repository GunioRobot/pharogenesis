slideDismissalsToTrash
	^ self
		valueOfFlag: #slideDismissalsToTrash
		ifAbsent: [true]