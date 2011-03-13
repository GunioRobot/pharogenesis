useUndo
	^ self
		valueOfFlag: #useUndo
		ifAbsent: [true]