readInto: aStringOrByteArray startingAt: aNumber 
	"Read data into the given buffer starting at the given index and return the number of bytes received. Note the given buffer may be only partially filled by the received data."

	(self waitForDataUntil: self class standardDeadline) 
		ifFalse: [self error: 'receive timeout'].
	^self 
		primSocket: socketHandle
		receiveDataInto: aStringOrByteArray
		startingAt: aNumber
		count: aStringOrByteArray size - aNumber + 1