infiniteUndo
	^ self
		valueOfFlag: #infiniteUndo
		ifAbsent: [false]