remoteTestClientTCPOpenClosePutGet
	"Socket remoteTestClientTCPOpenClosePutGet"

	| checkLength number bytesExpected sendBuf receiveBuf t1 socket bytesReceived serverName |
	Transcript
		show: 'starting client/server TCP test';
		cr.
	Transcript show: 'initializing network ... '.
	self initializeNetworkIfFail: [^Transcript show: 'failed'].
	Transcript
		show: 'ok';
		cr.
	serverName := FillInTheBlank request: 'What is your remote Test Server?'
				initialAnswer: ''.
	number := 1000.
	bytesExpected := 20000.
	sendBuf := String new: 80 withAll: $x.
	receiveBuf := String new: 50000.
	t1 := Time millisecondsToRun: 
					[number timesRepeat: 
							[socket := self newTCP.
							socket connectTo: (NetNameResolver addressFromString: serverName)
								port: 54321.
							socket waitForConnectionUntil: self standardDeadline.
							socket sendData: sendBuf.
							socket waitForSendDoneUntil: (self deadlineSecs: 5).
							socket waitForDataUntil: (self deadlineSecs: 5).
							bytesReceived := 0.
							[bytesReceived < bytesExpected] whileTrue: 
									[checkLength := socket receiveDataInto: receiveBuf.
									bytesReceived := bytesReceived + checkLength].
							socket closeAndDestroy]].
	Transcript
		cr;
		show: 'connects/get/put/close per second ' 
					, (number / t1 * 1000.0) printString;
		cr