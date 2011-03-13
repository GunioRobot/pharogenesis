securityChecksEnabled
	^ self
		valueOfFlag: #securityChecksEnabled
		ifAbsent: [false]