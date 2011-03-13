httpProxyPort
	^ self
		valueOfFlag: #httpProxyPort
		ifAbsent: [80]