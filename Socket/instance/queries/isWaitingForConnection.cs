isWaitingForConnection
	"Return true if this socket is waiting for a connection."

	^ (self primSocketConnectionStatus: socketHandle) == WaitingForConnection
