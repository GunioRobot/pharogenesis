remoteTestClientUDP
	"FIRST start up another image, and execute: Socket remoteTestServerUDP.
	THEN come back to this image and execute:"

	"Socket remoteTestClientUDP"

	"Performa 6400/200, Linux-PPC 2.1.24:
		remoteClient UDP test done; time = 4580
		2500 packets, 10000000 bytes sent (2183 kBytes/sec)
		180 packets, 720000 bytes received (157 kBytes/sec)
		4000 bytes/packet, 39 packets/sec, 2320 packets dropped"

	| socket bytesToSend sendBuf receiveBuf done bytesSent bytesReceived packetsSent packetsReceived t serverName |
	Transcript
		show: 'starting client/server UDP test';
		cr.
	Transcript show: 'initializing network ... '.
	self initializeNetworkIfFail: [^Transcript show: 'failed'].
	Transcript
		show: 'ok';
		cr.
	serverName := FillInTheBlank request: 'What is your remote Test Server?'
				initialAnswer: ''.
	socket := self newUDP.
	socket setPeer: (NetNameResolver addressFromString: serverName) port: 54321.
	Transcript
		show: 'client endpoint created';
		cr.
	bytesToSend := 10000000.
	sendBuf := String new: 4000 withAll: $x.
	receiveBuf := String new: 4000.
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
					
					[socket waitForDataUntil: (self deadlineSecs: 1).
					socket dataAvailable] 
							whileTrue: 
								[packetsReceived := packetsReceived + 1.
								bytesReceived := bytesReceived + (socket receiveDataInto: receiveBuf)]].
	socket closeAndDestroy.
	Transcript
		show: 'remoteClient UDP test done; time = ' , t printString;
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
		cr.
	Transcript
		show: (bytesSent // packetsSent) printString , ' bytes/packet, ' 
					, (packetsReceived * 1000 // t) printString , ' packets/sec, ' 
					, (packetsSent - packetsReceived) printString , ' packets dropped';
		cr