primAcceptFrom: aHandle receiveBufferSize: rcvBufSize sendBufSize: sndBufSize semaIndex: semaIndex readSemaIndex: aReadSema writeSemaIndex: aWriteSema
	"Create and return a new socket handle based on accepting the connection from the given listening socket"
	<primitive: 'primitiveSocketAccept3Semaphores' module: 'SocketPlugin'>
	primitiveOnlySupportsOneSemaphore _ true.
	^self primAcceptFrom: aHandle receiveBufferSize: rcvBufSize sendBufSize: sndBufSize semaIndex: semaIndex 