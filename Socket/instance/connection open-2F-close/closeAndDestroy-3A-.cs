closeAndDestroy: timeoutSeconds
	"First, try to close this connection gracefully. If the close attempt fails or times out, abort the connection. In either case, destroy the socket. Do nothing if the socket has already been destroyed (i.e., if its socketHandle is nil)."

	socketHandle = nil
		ifFalse: [
			self close.  "close this end"
			(self waitForDisconnectionUntil: (Socket deadlineSecs: timeoutSeconds))
				ifFalse: [
					"if the other end doesn't close soon, just abort the connection"
					self primSocketAbortConnection: socketHandle].
			self destroy].
