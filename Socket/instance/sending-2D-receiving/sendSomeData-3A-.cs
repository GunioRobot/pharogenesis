sendSomeData: aStringOrByteArray
	"Send as much of the given data as possible and return the number of bytes actually sent."
	"Note: This operation may have to be repeated many times to send a large amount of data."

	| bytesSent |
	(self waitForSendDoneUntil: (Socket deadlineSecs: 20))
		ifTrue: [
			bytesSent _ self primSocket: socketHandle
				sendData: aStringOrByteArray
				startIndex: 1
				count: aStringOrByteArray size]
		ifFalse: [self error: 'send data timeout; data not sent'].
	^ bytesSent
