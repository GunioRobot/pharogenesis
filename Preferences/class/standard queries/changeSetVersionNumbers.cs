changeSetVersionNumbers
	^ self
		valueOfFlag: #changeSetVersionNumbers
		ifAbsent: [true]