openConnectionToHostNamed: hostName port: portNumber
	| hostIP |
	hostIP _ NetNameResolver addressForName: hostName timeout: 20.
	^self openConnectionToHost: hostIP port: portNumber