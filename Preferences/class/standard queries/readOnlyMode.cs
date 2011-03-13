readOnlyMode
	^ self
		valueOfFlag: #readOnlyMode
		ifAbsent: [false]