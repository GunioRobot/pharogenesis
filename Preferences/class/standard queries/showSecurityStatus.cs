showSecurityStatus
	^ self
		valueOfFlag: #showSecurityStatus
		ifAbsent: [true]