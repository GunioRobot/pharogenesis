remoteTestClientTCP
	"FIRST start up another image, and execute: Socket remoteTestServerTCP.
	THEN come back to this image and execute:"
			"Socket remoteTestClientTCP"

	"Performa 6400/200, Linux-PPC 2.1.24, both images on same CPU:
		remoteClient TCP test done; time = 5680
		250 packets, 1000000 bytes sent (176 kBytes/sec)
		60 packets, 1000000 bytes received (176 kBytes/sec)"

	| socket bytesToSend sendBuf receiveBuf done bytesSent bytesReceived packetsSent packetsReceived t serverName |
	Transcript show: 'starting client/server TCP test'; cr.
	Transcript show: 'initializing network ... '.
	Socket initializeNetworkIfFail: [^Transcript show:'failed'].
	Transcript show:'ok';cr.
	socket _ Socket newTCP.
	serverName _ FillInTheBlank
		request: 'What is your remote Test Server?'
		initialAnswer: ''.
	socket connectTo: (NetNameResolver addressFromString: serverName) port: 54321.
	socket waitForConnectionUntil: Socket standardDeadline.
	Transcript show: 'client endpoint created'; cr.
	bytesToSend _ 1000000.
	sendBuf _ String new: 4000 withAll: $x.
	receiveBuf _ String new: 50000.
	done _ false.
	bytesSent _ bytesReceived _ packetsSent _ packetsReceived _ 0.
	t _ Time millisecondsToRun: [
		[done] whileFalse:
			[(socket sendDone and: [bytesSent < bytesToSend]) ifTrue:
				[packetsSent _ packetsSent + 1.
				bytesSent _ bytesSent + (socket sendData: sendBuf)].
			socket dataAvailable ifTrue:
				[packetsReceived _ packetsReceived + 1.
				bytesReceived _ bytesReceived + (socket receiveDataInto: receiveBuf)].
			done _ (bytesSent >= bytesToSend)].
		[bytesReceived < bytesToSend] whileTrue:
			[socket dataAvailable ifTrue:
				[packetsReceived _ packetsReceived + 1.
				bytesReceived _ bytesReceived + (socket receiveDataInto: receiveBuf)]]].
	socket closeAndDestroy.
	Transcript show: 'remoteClient TCP test done; time = ', t printString; cr.
	Transcript show: packetsSent printString, ' packets, ',
						bytesSent printString, ' bytes sent (',
						(bytesSent * 1000 // t) printString, ' bytes/sec)'; cr.
	Transcript show: packetsReceived printString, ' packets, ',
						bytesReceived printString, ' bytes received (',
						(bytesReceived * 1000 // t) printString, ' bytes/sec)'; cr.