remoteTestSinkTCP
	"See sendTest for instructions on running this method."
	"Socket remoteTestSinkTCP"

	| socket buffer n |
	Transcript show: 'initializing network ... '.
	Socket initializeNetworkIfFail: [^Transcript show:'failed'].
	Transcript show:'ok';cr.
	socket _ Socket newTCP.
	socket listenOn: 9.
	Transcript show: 'server endpoint created -- run client test in other image'; cr.
	buffer _ String new: 64000.
	socket waitForConnectionUntil: self standardDeadline.
	[socket isConnected] whileTrue: [
		socket dataAvailable ifTrue:
			[n _ socket	receiveDataInto: buffer]].
	socket closeAndDestroy.
	Transcript cr; show: 'sink endpoint destroyed'; cr.