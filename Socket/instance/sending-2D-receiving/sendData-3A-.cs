sendData: aStringOrByteArray
	"Send all of the data in the given array, even if it requires multiple calls to send it all. Return the number of bytes sent."

	| bytesSent bytesToSend count |
	bytesToSend _ aStringOrByteArray size.
	bytesSent _ 0.
	[bytesSent < bytesToSend] whileTrue: [
		(self waitForSendDoneUntil: (Socket deadlineSecs: 20))
			ifFalse: [self error: 'send data timeout; data not sent'].
		count _ self primSocket: socketHandle
			sendData: aStringOrByteArray
			startIndex: bytesSent + 1
			count: bytesToSend - bytesSent.
		bytesSent _ bytesSent + count].

	^ bytesSent
