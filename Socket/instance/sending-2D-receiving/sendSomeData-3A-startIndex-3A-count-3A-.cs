sendSomeData: aStringOrByteArray startIndex: startIndex count: count
	"Send up to count bytes of the given data starting at the given index. Answer the number of bytes actually sent."
	"Note: This operation may have to be repeated multiple times to send a large amount of data."

	| bytesSent |
	(self waitForSendDoneUntil: (Socket deadlineSecs: 20))
		ifTrue: [
			bytesSent _ self primSocket: socketHandle
				sendData: aStringOrByteArray
				startIndex: startIndex
				count: count]
		ifFalse: [self error: 'send data timeout; data not sent'].
	^ bytesSent
