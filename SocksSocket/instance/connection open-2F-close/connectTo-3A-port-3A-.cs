connectTo: hostAddress port: port
	self initializeNetwork.
	self shouldUseSocks
		ifFalse: [^super connectTo: hostAddress port: port].
	super connectTo: socksIP port: socksPort.
	self waitForConnectionUntil: Socket standardDeadline.
	dstIP _ hostAddress.
	dstPort _ port.
	vers == 4
		ifTrue: [self connectSocks4]
		ifFalse: [self connectSocks5]
	