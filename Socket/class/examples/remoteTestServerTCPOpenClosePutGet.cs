remoteTestServerTCPOpenClosePutGet	
	"The version of #remoteTestServerTCPOpenClosePutGet using the BSD style accept() mechanism."
	"Socket remoteTestServerTCPOpenClosePutGet"

	| socket server bytesIWantToSend bytesExpected receiveBuf sendBuf checkLength |
	Transcript show: 'initializing network ... '.
	Socket initializeNetworkIfFail: [^Transcript show:'failed'].
	Transcript show:'ok';cr.
	server _ Socket newTCP.
	server listenOn: 54321 backlogSize: 20.
	server isValid ifFalse:[self error:'Accept() is not supported'].
	Transcript show: 'server endpoint created -- run client test in other image'; cr.
	bytesIWantToSend _ 20000.
	bytesExpected _ 80.
	receiveBuf _ String new: 40000.
	sendBuf _ String new: bytesIWantToSend withAll: $x.
	1000 timesRepeat: 
		[socket _ server waitForAcceptUntil: (Socket deadlineSecs: 300).
		socket waitForDataUntil: (Socket deadlineSecs: 5).
		checkLength _ socket receiveDataInto: receiveBuf.
		(checkLength ~= bytesExpected) ifTrue: [self halt].
		socket sendData: sendBuf.
		socket waitForSendDoneUntil: (Socket deadlineSecs: 5).		
		socket closeAndDestroy].
	server closeAndDestroy.
	Transcript cr; show: 'server endpoint destroyed'; cr.
