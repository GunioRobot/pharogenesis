remoteTestServerUDP
	"See remoteTestClientUDP for instructions on running this method."

	"Socket remoteTestServerUDP"

	| socket buffer n |
	Transcript show: 'initializing network ... '.
	self initializeNetworkIfFail: [^Transcript show: 'failed'].
	Transcript
		show: 'ok';
		cr.
	socket := self newUDP.
	socket setPort: 54321.
	Transcript
		show: 'server endpoint created -- run client test in other image';
		cr.
	buffer := String new: 4000.
	[true] whileTrue: 
			[socket dataAvailable 
				ifTrue: 
					[n := socket receiveDataInto: buffer.
					socket sendData: buffer count: n]]