remoteTestClientTCPOpenClose1000
	"Socket remoteTestClientTCPOpenClose1000"

	| number t1 socket serverName |
	Transcript
		show: 'starting client/server TCP test';
		cr.
	Transcript show: 'initializing network ... '.
	self initializeNetworkIfFail: [^Transcript show: 'failed'].
	Transcript
		show: 'ok';
		cr.
	number := 1000.
	serverName := FillInTheBlank request: 'What is your remote Test Server?'
				initialAnswer: ''.
	t1 := Time millisecondsToRun: 
					[number timesRepeat: 
							[socket := self newTCP.
							socket connectTo: (NetNameResolver addressFromString: serverName)
								port: 54321.
							socket waitForConnectionUntil: self standardDeadline.
							socket closeAndDestroy]].
	Transcript
		cr;
		show: 'connects/close per second ' , (number / t1 * 1000.0) printString;
		cr