standaloneSecurityChecksEnabled
	^ self
		valueOfFlag: #standaloneSecurityChecksEnabled
		ifAbsent: [false]