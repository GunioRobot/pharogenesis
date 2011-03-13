purgeUndoOnQuit
	^ self
		valueOfFlag: #purgeUndoOnQuit
		ifAbsent: [true]