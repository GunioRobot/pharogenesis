remoteTestServerTCPOpenClosePutGet
	"The version of #remoteTestServerTCPOpenClosePutGet using the BSD style accept() mechanism."

	"Socket remoteTestServerTCPOpenClosePutGet"

	| socket server bytesIWantToSend bytesExpected receiveBuf sendBuf checkLength |
	Transcript show: 'initializing network ... '.
	self initializeNetworkIfFail: [^Transcript show: 'failed'].
	Transcript
		show: 'ok';
		cr.
	server := self newTCP.
	server listenOn: 54321 backlogSize: 20.
	server isValid ifFalse: [self error: 'Accept() is not supported'].
	Transcript
		show: 'server endpoint created -- run client test in other image';
		cr.
	bytesIWantToSend := 20000.
	bytesExpected := 80.
	receiveBuf := String new: 40000.
	sendBuf := String new: bytesIWantToSend withAll: $x.
	1000 timesRepeat: 
			[socket := server waitForAcceptUntil: (self deadlineSecs: 300).
			socket waitForDataUntil: (self deadlineSecs: 5).
			checkLength := socket receiveDataInto: receiveBuf.
			checkLength ~= bytesExpected ifTrue: [self halt].
			socket sendData: sendBuf.
			socket waitForSendDoneUntil: (self deadlineSecs: 5).
			socket closeAndDestroy].
	server closeAndDestroy.
	Transcript
		cr;
		show: 'server endpoint destroyed';
		cr