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
	Transcript show: 'starting client/server UDP test'; cr.
	Transcript show: 'initializing network ... '.
	Socket initializeNetworkIfFail: [^Transcript show:'failed'].
	Transcript show:'ok';cr.
	serverName _ FillInTheBlank
		request: 'What is your remote Test Server?'
		initialAnswer: ''.
	socket _ Socket newUDP.
	socket setPeer: (NetNameResolver addressFromString: serverName) port: 54321.
	Transcript show: 'client endpoint created'; cr.
	bytesToSend _ 10000000.
	sendBuf _ String new: 4000 withAll: $x.
	receiveBuf _ String new: 4000.
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
	[socket waitForDataUntil: (Socket deadlineSecs: 1).
	socket dataAvailable] whileTrue:
		[packetsReceived _ packetsReceived + 1.
		bytesReceived _ bytesReceived + (socket receiveDataInto: receiveBuf)]].
	socket closeAndDestroy.
	Transcript show: 'remoteClient UDP test done; time = ', t printString; cr.
	Transcript show: packetsSent printString, ' packets, ',
						bytesSent printString, ' bytes sent (',
						(bytesSent * 1000 // t) printString, ' bytes/sec)'; cr.
	Transcript show: packetsReceived printString, ' packets, ',
						bytesReceived printString, ' bytes received (',
						(bytesReceived * 1000 // t) printString, ' bytes/sec)'; cr.
	Transcript show: (bytesSent // packetsSent) printString, ' bytes/packet, ',
						(packetsReceived * 1000 // t) printString, ' packets/sec, ',
						(packetsSent - packetsReceived) printString, ' packets dropped'; cr.