loopbackTest
	"Send data from one socket to another on the local machine. Tests most of the socket primitives."
	"100 timesRepeat: [Socket loopbackTest]"

	| sock1 sock2 bytesToSend sendBuf receiveBuf done bytesSent bytesReceived t extraBytes packetsSent packetsRead |
	Transcript cr; show: 'starting loopback test'; cr.

	Transcript show: '---------- Connecting ----------'; cr.
	Socket initializeNetwork.
	sock1 _ Socket new.
	sock2 _ Socket new.
	sock1 listenOn: 54321.
	sock2 connectTo: (NetNameResolver localHostAddress) port: 54321.
	sock1 waitForConnectionUntil: self standardDeadline.
	sock2 waitForConnectionUntil: self standardDeadline.
	(sock1 isConnected) ifFalse: [self error: 'sock1 not connected'].
	(sock2 isConnected) ifFalse: [self error: 'sock2 not connected'].
	Transcript show: 'connection established'; cr.

	bytesToSend _ 5000000.
	sendBuf _ String new: 5000 withAll: $x.
	receiveBuf _ String new: 50000.
	done _ false.
	packetsSent _ packetsRead _ bytesSent _ bytesReceived _ 0.
	t _ Time millisecondsToRun: [
		[done] whileFalse: [
			(sock1 sendDone and: [bytesSent < bytesToSend]) ifTrue: [
				packetsSent _ packetsSent + 1.
				bytesSent _ bytesSent + (sock1 sendSomeData: sendBuf)].
			sock2 dataAvailable ifTrue: [
				packetsRead _ packetsRead + 1.
				bytesReceived _ bytesReceived +
					(sock2 receiveDataInto: receiveBuf)].
			done _ (bytesSent >= bytesToSend) and: [bytesReceived = bytesSent]]].
	
	Transcript show: 'closing connection'; cr.
	sock1 waitForSendDoneUntil: self standardDeadline.
	sock1 close.
	sock2 waitForDisconnectionUntil: self standardDeadline.
	extraBytes _ sock2 discardReceivedData.
	extraBytes > 0 ifTrue: [
		Transcript show: ' *** received ', extraBytes size printString, ' extra bytes ***'; cr.
	].
	sock2 close.
	sock1 waitForDisconnectionUntil: self standardDeadline.
	(sock1 isUnconnectedOrInvalid) ifFalse: [self error: 'sock1 not closed'].
	(sock2 isUnconnectedOrInvalid) ifFalse: [self error: 'sock2 not closed'].
	Transcript show: '---------- Connection Closed ----------'; cr.

	sock1 destroy.
	sock2 destroy.
	Transcript show: 'loopback test done; time = ', t printString; cr.
	Transcript show: ((bytesToSend asFloat / t) roundTo: 0.01) printString, ' 1000Bytes/sec'; cr.
	Transcript endEntry.
