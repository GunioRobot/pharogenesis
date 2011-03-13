preserveTrash
	^ self
		valueOfFlag: #preserveTrash
		ifAbsent: [false]