dataAvailable
	"Return true if this socket has unread received data."

	^ self primSocketReceiveDataAvailable: socketHandle
