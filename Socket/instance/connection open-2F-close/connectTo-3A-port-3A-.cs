connectTo: hostAddress port: port
	"Initiate a connection to the given port at the given host address.
	Waits until the connection is established or time outs."

	NetNameResolver useOldNetwork
		ifTrue: [self connectTo: hostAddress port: port waitForConnectionFor: Socket standardTimeout]
		ifFalse: [
			hostAddress port: port.
			self connectTo: hostAddress]