remoteTestServerTCPOpenClose1000
	"The version of #remoteTestServerTCPOpenClose1000 using the BSD style accept() mechanism."
	"Socket remoteTestServerTCPOpenClose1000"

	| socket server |
	Transcript show: 'initializing network ... '.
	Socket initializeNetworkIfFail: [^Transcript show:'failed'].
	Transcript show:'ok';cr.
	server _ Socket newTCP.
	server listenOn: 54321 backlogSize: 20.
	server isValid ifFalse:[self error:'Accept() is not supported'].
	Transcript show: 'server endpoint created -- run client test in other image'; cr.
	1000 timesRepeat: 
		[socket _ server waitForAcceptUntil: (Socket deadlineSecs: 300).
		socket closeAndDestroy].
	server closeAndDestroy.
	Transcript cr; show: 'server endpoint destroyed'; cr.
