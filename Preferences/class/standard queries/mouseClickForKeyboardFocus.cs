mouseClickForKeyboardFocus
	^ self
		valueOfFlag: #mouseClickForKeyboardFocus
		ifAbsent: [false]