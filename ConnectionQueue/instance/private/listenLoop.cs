listenLoop
	"Private! This loop is run in a separate process. It will establish up to maxQueueLength connections on the given port."
	"Details: When out of sockets or queue is full, retry more frequently, since a socket may become available, space may open in the queue, or a previously queued connection may be aborted by the client, making it available for a fresh connection."

	[true] whileTrue: [
		((socket == nil) and: [connections size < maxQueueLength]) ifTrue: [
			"try to create a new socket for listening"
			socket _ Socket createIfFail: [nil]].

		socket == nil
			ifTrue: [(Delay forMilliseconds: 100) wait]
			ifFalse: [
				socket isUnconnected ifTrue: [socket listenOn: portNumber].
				socket waitForConnectionUntil: (Socket deadlineSecs: 10).
				socket isConnected
					ifTrue: [  "connection established"
						accessSema critical: [connections addLast: socket].
						socket _ nil]
					ifFalse: [
						(socket isWaitingForConnection or:
						 [socket isUnconnected])
							ifFalse: [socket destroy. socket _ nil]]].  "return to unconnected state"

		self pruneStaleConnections].
