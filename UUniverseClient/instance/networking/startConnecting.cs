startConnecting
	"start a new connection to the server"
	self disconnect.
	
	lastConnectionStart _ DateAndTime now.
	
	socket _ Socket newTCP.
	socket connectTo: (NetNameResolver addressForName: universe serverName) port: universe serverPort.
