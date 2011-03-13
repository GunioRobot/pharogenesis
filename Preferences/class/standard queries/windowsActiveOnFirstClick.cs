windowsActiveOnFirstClick
	^ self
		valueOfFlag: #windowsActiveOnFirstClick
		ifAbsent: [false]