listenOn: port
	"Listen for a connection on the given port. This operation will return immediately; follow it with waitForConnectionUntil: to wait until a connection is established."

	| status |
	status _ self primSocketConnectionStatus: socketHandle.
	(status == Unconnected)
		ifFalse: [self error: 'Socket status must Unconnected before listening for a new connection'].

	self primSocket: socketHandle listenOn: port.
