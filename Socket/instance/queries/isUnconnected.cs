isUnconnected
	"Return true if this socket is connected."

	^ (self primSocketConnectionStatus: socketHandle) == Unconnected
