clientServerTestUDP2
	"Socket clientServerTestUDP2"

	| sock1 sock2 bytesToSend sendBuf receiveBuf done bytesSent bytesReceived packetsSent packetsReceived t datagramInfo |
	Transcript
		show: 'starting client/server UDP test';
		cr.
	Transcript show: 'initializing network ... '.
	self initializeNetworkIfFail: [^Transcript show: 'failed'].
	Transcript
		show: 'ok';
		cr.
	Transcript
		show: 'creating endpoints';
		cr.
	sock1 := self newUDP.	"the sender"
	sock2 := self newUDP.	"the recipient"
	sock2 setPort: 54321.
	Transcript
		show: 'endpoints created';
		cr.
	bytesToSend := 100000000.
	sendBuf := String new: 4000 withAll: $x.
	receiveBuf := String new: 2000.
	done := false.
	bytesSent := bytesReceived := packetsSent := packetsReceived := 0.
	t := Time millisecondsToRun: 
					[[done] whileFalse: 
							[(sock1 sendDone and: [bytesSent < bytesToSend]) 
								ifTrue: 
									[packetsSent := packetsSent + 1.
									bytesSent := bytesSent + (sock1 
														sendData: sendBuf
														toHost: NetNameResolver localHostAddress
														port: sock2 port)].
							sock2 dataAvailable 
								ifTrue: 
									[packetsReceived := packetsReceived + 1.
									datagramInfo := sock2 receiveUDPDataInto: receiveBuf.
									bytesReceived := bytesReceived + (datagramInfo at: 1)].
							done := bytesSent >= bytesToSend].
					sock1 waitForSendDoneUntil: self standardDeadline.
					bytesReceived := bytesReceived + sock2 discardReceivedData].
	Transcript
		show: 'closing endpoints';
		cr.
	sock1 close.
	sock2 close.
	sock1 destroy.
	sock2 destroy.
	Transcript
		show: 'client/server UDP test done; time = ' , t printString;
		cr.
	Transcript
		show: packetsSent printString , ' packets, ' , bytesSent printString 
					, ' bytes sent (' , (bytesSent * 1000 // t) printString 
					, ' Bytes/sec)';
		cr.
	Transcript
		show: packetsReceived printString , ' packets, ' 
					, bytesReceived printString , ' bytes received (' 
					, (bytesReceived * 1000 // t) printString , ' Bytes/sec)';
		cr.
	Transcript
		show: (bytesSent // packetsSent) printString , ' bytes/packet, ' 
					, (packetsReceived * 1000 // t) printString , ' packets/sec, ' 
					, (packetsSent - packetsReceived) printString , ' packets dropped';
		cr