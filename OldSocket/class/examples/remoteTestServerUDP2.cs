remoteTestServerUDP2
	"See remoteTestClientUDP for instructions on running this method."

	"Socket remoteTestServerUDP2"

	| socket buffer datagramInfo |
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
	buffer := String new: 65000.
	[true] whileTrue: 
			[socket dataAvailable 
				ifTrue: 
					[datagramInfo := socket receiveUDPDataInto: buffer.
					Transcript
						show: datagramInfo printString;
						cr.
					socket sendData: buffer count: (datagramInfo at: 1)]]