remoteCursorTest
	"This version of the remote cursor test runs both the client and the server code in the same loop."
	"SimpleClientSocket remoteCursorTest"

	| sock1 sock2 samplesToSend samplesSent done t |
	Transcript show: 'starting remote cursor test'; cr.
	Transcript show: 'initializing network'; cr.
	Socket initializeNetwork.
	Transcript show: 'opening connection'; cr.
	sock1 _ SimpleClientSocket new.
	sock2 _ SimpleClientSocket new.
	sock1 listenOn: 54321.
	sock2 connectTo: (NetNameResolver localHostAddress) port: 54321.
	sock1 waitForConnectionUntil: self standardDeadline.
	sock2 waitForConnectionUntil: self standardDeadline.
	(sock1 isConnected) ifFalse: [self error: 'sock1 not connected'].
	(sock2 isConnected) ifFalse: [self error: 'sock2 not connected'].
	Transcript show: 'connection established'; cr.

	samplesToSend _ 100.
	t _ Time millisecondsToRun: [
		samplesSent _ 0.
		done _ false.
		[done]
			whileFalse: [
				(sock1 sendDone and: [samplesSent < samplesToSend]) ifTrue: [
					sock1 sendCommand: self sensorStateString.
					samplesSent _ samplesSent + 1].
				sock2 dataAvailable ifTrue: [
					sock2 getResponse displayOn: Display at: 10@10].
				done _ samplesSent = samplesToSend]].
	sock1 destroy.
	sock2 destroy.
	Transcript show: 'remote cursor test done'; cr.
	Transcript show:
		samplesSent printString, ' samples sent in ',
		t printString, ' milliseconds'; cr.
	Transcript show: ((samplesSent * 1000) // t) printString, ' samples/sec'; cr.
