connectToHostNamed: hostName port: portNumber
	| serverIP |
	serverIP _ NetNameResolver addressForName: hostName timeout: 20.
	^self connectTo: serverIP port: portNumber
