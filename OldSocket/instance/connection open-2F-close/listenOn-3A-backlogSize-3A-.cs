listenOn: portNumber backlogSize: backlog
	"Listen for a connection on the given port.
	If this method succeeds, #accept may be used to establish a new connection"
	| status |
	status _ self primSocketConnectionStatus: socketHandle.
	(status == Unconnected)
		ifFalse: [self error: 'Socket status must Unconnected before listening for a new connection'].
	self primSocket: socketHandle listenOn: portNumber backlogSize: backlog.
