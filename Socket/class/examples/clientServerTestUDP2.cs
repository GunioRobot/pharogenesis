clientServerTestUDP2
	"Socket clientServerTestUDP2"

	| sock1 sock2 bytesToSend sendBuf receiveBuf done bytesSent bytesReceived packetsSent packetsReceived t datagramInfo |
	Transcript show: 'starting client/server UDP test'; cr.
	Transcript show: 'initializing network ... '.
	Socket initializeNetworkIfFail: [^Transcript show:'failed'].
	Transcript show:'ok';cr.
	Transcript show: 'creating endpoints'; cr.
	sock1 _ Socket newUDP.	"the sender"
	sock2 _ Socket newUDP.	"the recipient"
	sock2 setPort: 54321.
	Transcript show: 'endpoints created'; cr.

	bytesToSend _ 100000000.
	sendBuf _ String new: 4000 withAll: $x.
	receiveBuf _ String new: 2000.
	done _ false.
	bytesSent _ bytesReceived _ packetsSent _ packetsReceived _ 0.
	t _ Time millisecondsToRun: [
		[done] whileFalse: [
			(sock1 sendDone and: [bytesSent < bytesToSend]) ifTrue: [
				packetsSent _ packetsSent + 1.
				bytesSent _ bytesSent + (sock1 sendData: sendBuf toHost: (NetNameResolver localHostAddress) port: (sock2 port))].	
			sock2 dataAvailable ifTrue: [
				packetsReceived _ packetsReceived + 1.
				datagramInfo _ sock2 receiveUDPDataInto: receiveBuf.
				bytesReceived _ bytesReceived + (datagramInfo at: 1)].
			done _ (bytesSent >= bytesToSend)].
		sock1 waitForSendDoneUntil: self standardDeadline.
		bytesReceived _ bytesReceived + sock2 discardReceivedData].

	Transcript show: 'closing endpoints'; cr.
	sock1 close.
	sock2 close.
	sock1 destroy.
	sock2 destroy.
	Transcript show: 'client/server UDP test done; time = ', t printString; cr.
	Transcript show: packetsSent printString, ' packets, ',
						bytesSent printString, ' bytes sent (',
						(bytesSent * 1000 // t) printString, ' Bytes/sec)'; cr.
	Transcript show: packetsReceived printString, ' packets, ',
						bytesReceived printString, ' bytes received (',
						(bytesReceived * 1000 // t) printString, ' Bytes/sec)'; cr.
	Transcript show: (bytesSent // packetsSent) printString, ' bytes/packet, ',
						(packetsReceived * 1000 // t) printString, ' packets/sec, ',
						(packetsSent - packetsReceived) printString, ' packets dropped'; cr.