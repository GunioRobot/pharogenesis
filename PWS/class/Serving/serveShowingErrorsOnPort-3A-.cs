serveShowingErrorsOnPort: portNumber
	"Start up the HTTP server loop for debugging!  Operate in this
process, synchronously.  Force errors to stop the server and show on the
screen.."

	| socket logEntry inst |
	self stopServer.
	Socket initializeNetwork.
	ServerLog _ FileStream fileNamed: 'dummy.log'.
	ServerLog position: ServerLog size.
	ServerPort _ ConnectionQueue portNumber: portNumber queueLength: 6.
	ClientNameCache _ Dictionary new.

	[true] whileTrue: [
		socket _ ServerPort getConnectionOrNil.
		socket notNil
			ifTrue: ["serve:"
				inst _ self new.
				inst initializeFrom: socket.
				inst getReply.
				socket closeAndDestroy: 30.
				logEntry _ inst log contents]		"no
logging for now"
			ifFalse: [(Delay forMilliseconds: 100) wait]].
