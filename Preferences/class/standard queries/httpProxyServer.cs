httpProxyServer
	^ self
		valueOfFlag: #httpProxyServer
		ifAbsent: ['']