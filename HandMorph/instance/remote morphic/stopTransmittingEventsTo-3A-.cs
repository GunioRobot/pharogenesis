stopTransmittingEventsTo: addr
	"Stop broadcasting events from this world's cursor to a remote cursor on the host with the given address. This method issues a 'close' but does not destroy the socket; it will be destroyed when the other end reads the last data and closes the connection."

	| sock |
	remoteConnections do: [:triple |
		sock _ triple first.
		(sock isUnconnectedOrInvalid not and: [sock remoteAddress = addr]) ifTrue: [
			sock close.
			triple at: 2 put: #closing]].
