remoteTestServerTCPUsingAccept
	"The version of #remoteTestServer using the BSD style accept() mechanism."

	"Socket remoteTestServerTCPUsingAccept"

	| socket buffer n server |
	Transcript show: 'initializing network ... '.
	self initializeNetworkIfFail: [^Transcript show: 'failed'].
	Transcript
		show: 'ok';
		cr.
	server := self newTCP.
	server listenOn: 54321 backlogSize: 4.
	server isValid ifFalse: [self error: 'Accept() is not supported'].
	Transcript
		show: 'server endpoint created -- run client test in other image';
		cr.
	buffer := String new: 40000.
	10 timesRepeat: 
			[socket := server waitForAcceptUntil: (self deadlineSecs: 300).
			[socket isConnected] whileTrue: 
					[socket dataAvailable 
						ifTrue: 
							[n := socket receiveDataInto: buffer.
							socket sendData: buffer count: n]]].
	socket closeAndDestroy.
	server closeAndDestroy.
	Transcript
		cr;
		show: 'server endpoint destroyed';
		cr