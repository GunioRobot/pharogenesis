remoteTestClientTCPOpenClosePutGet
	"Socket remoteTestClientTCPOpenClosePutGet"

	| checkLength number bytesExpected sendBuf receiveBuf t1 socket bytesReceived serverName | 

	Transcript show: 'starting client/server TCP test'; cr.
	Transcript show: 'initializing network ... '.
	Socket initializeNetworkIfFail: [^Transcript show:'failed'].
	Transcript show:'ok';cr.
	serverName _ FillInTheBlank
		request: 'What is your remote Test Server?'
		initialAnswer: ''.
	number _ 1000.	
	bytesExpected _ 20000.
	sendBuf _ String new: 80 withAll: $x.
	receiveBuf _ String new: 50000.
	t1 _ Time millisecondsToRun: 
		[number timesRepeat: 
		[socket _ Socket newTCP.
		socket connectTo: (NetNameResolver addressFromString: serverName) port: 54321.
		socket waitForConnectionUntil: Socket standardDeadline.
		socket sendData: sendBuf.
		socket waitForSendDoneUntil: (Socket deadlineSecs: 5).
		socket waitForDataUntil: (Socket deadlineSecs: 5).
		bytesReceived _ 0.
		[bytesReceived < bytesExpected] whileTrue:
			[checkLength _ socket receiveDataInto: receiveBuf.
			bytesReceived _ bytesReceived + checkLength].
		socket closeAndDestroy]].
	Transcript cr;show: 'connects/get/put/close per second ', ((number/t1*1000.0) printString); cr.

