connectToHostNamed: hostName port: port
	super connectTo: socksIP port: socksPort.
	self waitForConnectionUntil: Socket standardDeadline.
	dstName _ hostName.
	dstPort _ port.
	vers == 4
		ifTrue: [self connectSocks4]
		ifFalse: [self connectSocks5]
	