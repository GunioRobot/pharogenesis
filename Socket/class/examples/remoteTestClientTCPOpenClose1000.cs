remoteTestClientTCPOpenClose1000
	"Socket remoteTestClientTCPOpenClose1000"
	| number t1 socket serverName |
	Transcript show: 'starting client/server TCP test'; cr.
	Transcript show: 'initializing network ... '.
	Socket initializeNetworkIfFail: [^Transcript show:'failed'].
	Transcript show:'ok';cr.
	number _ 1000.
	serverName _ FillInTheBlank
		request: 'What is your remote Test Server?'
		initialAnswer: ''.
	t1 _ Time millisecondsToRun: 
		[number timesRepeat: 
		[socket _ Socket newTCP.
		socket connectTo: (NetNameResolver addressFromString: serverName) port: 54321.
		socket waitForConnectionUntil: Socket standardDeadline.
		socket closeAndDestroy]].
	Transcript cr;show: 'connects/close per second ', ((number/t1*1000.0) printString); cr.

