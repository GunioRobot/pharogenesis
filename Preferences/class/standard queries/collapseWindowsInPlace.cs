collapseWindowsInPlace
	^ self
		valueOfFlag: #collapseWindowsInPlace
		ifAbsent: [false]