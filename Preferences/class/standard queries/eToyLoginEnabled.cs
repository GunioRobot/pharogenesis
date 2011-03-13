eToyLoginEnabled
	^ self
		valueOfFlag: #eToyLoginEnabled
		ifAbsent: [false]