sendTest
	"Send data to the 'discard' socket of the given host. Tests the speed of one-way data transfers across the network to the given host. Note that many host hosts do not run a discard server."
	"Socket sendTest"

	| sock bytesToSend sendBuf bytesSent t serverName serverAddr |
	Transcript cr; show: 'starting send test'; cr.
	Socket initializeNetwork.
	serverName _ FillInTheBlank
		request: 'What is the destination server?'
		initialAnswer: 'create.ucsb.edu'.
	serverAddr _ NetNameResolver addressForName: serverName timeout: 10.
	serverAddr = nil ifTrue: [^ self inform: 'Could not find an address for ', serverName].

	sock _ Socket new.
	Transcript show: '---------- Connecting ----------'; cr.
	sock connectTo: serverAddr port: 9.
	sock waitForConnectionUntil: self standardDeadline.
	(sock isConnected) ifFalse: [
		sock destroy.
		^ self inform: 'could not connect'].
	Transcript show: 'connection established; sending data'; cr.

	bytesToSend _ 1000000.
	sendBuf _ String new: 64*1024 withAll: $x.
	bytesSent _ 0.
	t _ Time millisecondsToRun: [
		[bytesSent < bytesToSend] whileTrue: [
			sock sendDone ifTrue: [
				bytesSent _ bytesSent + (sock sendSomeData: sendBuf)]]].
	sock waitForSendDoneUntil: self standardDeadline.
	sock destroy.
	Transcript show: '---------- Connection Closed ----------'; cr.
	Transcript show: 'send test done; time = ', t printString; cr.
	Transcript show: ((bytesToSend asFloat / t) roundTo: 0.01) printString, ' 1000Bytes/sec'; cr.
	Transcript endEntry.
