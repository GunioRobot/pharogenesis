remoteTestServerTCP
	"See remoteTestClientTCP for instructions on running this method."
	"Socket remoteTestServerTCP"

	| socket buffer n |
	Transcript show: 'initializing network ... '.
	Socket initializeNetworkIfFail: [^Transcript show:'failed'].
	Transcript show:'ok';cr.
	socket _ Socket newTCP.
	socket listenOn: 54321.
	Transcript show: 'server endpoint created -- run client test in other image'; cr.
	buffer _ String new: 4000.
	socket waitForConnectionUntil: self standardDeadline.
	[socket isConnected] whileTrue: [
		socket dataAvailable ifTrue:
			[n _ socket	receiveDataInto: buffer.
			socket sendData: buffer count: n]].
	socket closeAndDestroy.
	Transcript cr; show: 'server endpoint destroyed'; cr.