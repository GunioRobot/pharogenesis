clientServerTestUDP
	"Socket clientServerTestUDP"

	"Performa 6400/200, Linux-PPC 2.1.24:
		client/server UDP test done; time = 2820
		2500 packets, 10000000 bytes sent (3546 kBytes/sec)
		2500 packets, 10000000 bytes received (3546 kBytes/sec)
		4000 bytes/packet, 886 packets/sec, 0 packets dropped"

	| sock1 sock2 bytesToSend sendBuf receiveBuf done bytesSent bytesReceived packetsSent packetsReceived t |
	Transcript show: 'starting client/server UDP test'; cr.
	Transcript show: 'initializing network ... '.
	Socket initializeNetworkIfFail: [^Transcript show:'failed'].
	Transcript show:'ok';cr.
	Transcript show: 'creating endpoints'; cr.
	sock1 _ Socket newUDP.	"the sender"
	sock2 _ Socket newUDP.	"the recipient"
	sock2 setPort: 54321.
	sock1 setPeer: (NetNameResolver localHostAddress) port: (sock2 port).
	Transcript show: 'endpoints created'; cr.

	bytesToSend _ 10000000.
	sendBuf _ String new: 4000 withAll: $x.
	receiveBuf _ String new: 50000.
	done _ false.
	bytesSent _ bytesReceived _ packetsSent _ packetsReceived _ 0.
	t _ Time millisecondsToRun: [
		[done] whileFalse: [
			(sock1 sendDone and: [bytesSent < bytesToSend]) ifTrue: [
				packetsSent _ packetsSent + 1.
				bytesSent _ bytesSent + (sock1 sendData: sendBuf)].
			sock2 dataAvailable ifTrue: [
				packetsReceived _ packetsReceived + 1.
				bytesReceived _ bytesReceived +
					(sock2 receiveDataInto: receiveBuf)].
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