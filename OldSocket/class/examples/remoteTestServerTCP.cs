remoteTestServerTCP
	"See remoteTestClientTCP for instructions on running this method."

	"OldSocket remoteTestServerTCP"

	| socket client buffer n |
	Transcript show: 'initializing network ... '.
	self initializeNetwork.
	Transcript
		show: 'ok';
		cr.
	socket := OldSocket newTCP.
	socket 
		listenOn: 54321
		backlogSize: 5
		interface: (NetNameResolver addressFromString: '127.0.0.1').	"or: 0.0.0.0"
	Transcript
		show: 'server endpoint created -- run client test in other image';
		cr.
	buffer := String new: 4000.
	socket waitForConnectionUntil: self standardDeadline.
	client := socket accept.
	[client isConnected] whileTrue: 
			[client dataAvailable 
				ifTrue: 
					[n := client receiveDataInto: buffer.
					client sendData: buffer count: n]].
	client closeAndDestroy.
	socket closeAndDestroy.
	Transcript
		cr;
		show: 'server endpoint destroyed';
		cr.
	^socket