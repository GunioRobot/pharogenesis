openOnHostNamed: hostName port: portNumber
	| serverIP |
	serverIP _ NetNameResolver addressForName: hostName timeout: 20.
	^self openOnHost: serverIP port: portNumber
