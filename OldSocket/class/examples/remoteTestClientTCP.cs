remoteTestClientTCP
	"FIRST start up another image, and execute: Socket remoteTestServerTCP.
	THEN come back to this image and execute:"

	"Socket remoteTestClientTCP"

	"Performa 6400/200, Linux-PPC 2.1.24, both images on same CPU:
		remoteClient TCP test done; time = 5680
		250 packets, 1000000 bytes sent (176 kBytes/sec)
		60 packets, 1000000 bytes received (176 kBytes/sec)"

	| socket bytesToSend sendBuf receiveBuf done bytesSent bytesReceived packetsSent packetsReceived t serverName |
	Transcript
		show: 'starting client/server TCP test';
		cr.
	Transcript show: 'initializing network ... '.
	self initializeNetworkIfFail: [^Transcript show: 'failed'].
	Transcript
		show: 'ok';
		cr.
	socket := self newTCP.
	serverName := FillInTheBlank request: 'What is your remote Test Server?'
				initialAnswer: ''.
	socket connectTo: (NetNameResolver addressFromString: serverName)
		port: 54321.
	socket waitForConnectionUntil: self standardDeadline.
	Transcript
		show: 'client endpoint created';
		cr.
	bytesToSend := 1000000.
	sendBuf := String new: 4000 withAll: $x.
	receiveBuf := String new: 50000.
	done := false.
	bytesSent := bytesReceived := packetsSent := packetsReceived := 0.
	t := Time millisecondsToRun: 
					[[done] whileFalse: 
							[(socket sendDone and: [bytesSent < bytesToSend]) 
								ifTrue: 
									[packetsSent := packetsSent + 1.
									bytesSent := bytesSent + (socket sendData: sendBuf)].
							socket dataAvailable 
								ifTrue: 
									[packetsReceived := packetsReceived + 1.
									bytesReceived := bytesReceived + (socket receiveDataInto: receiveBuf)].
							done := bytesSent >= bytesToSend].
					[bytesReceived < bytesToSend] whileTrue: 
							[socket dataAvailable 
								ifTrue: 
									[packetsReceived := packetsReceived + 1.
									bytesReceived := bytesReceived + (socket receiveDataInto: receiveBuf)]]].
	socket closeAndDestroy.
	Transcript
		show: 'remoteClient TCP test done; time = ' , t printString;
		cr.
	Transcript
		show: packetsSent printString , ' packets, ' , bytesSent printString 
					, ' bytes sent (' , (bytesSent * 1000 // t) printString 
					, ' bytes/sec)';
		cr.
	Transcript
		show: packetsReceived printString , ' packets, ' 
					, bytesReceived printString , ' bytes received (' 
					, (bytesReceived * 1000 // t) printString , ' bytes/sec)';
		cr