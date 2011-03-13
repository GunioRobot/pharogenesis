startInUntrustedDirectory
	^ self
		valueOfFlag: #startInUntrustedDirectory
		ifAbsent: [false]