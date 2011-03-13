getDataTo: dataStream whileWatching: otherSocket
	"Reel in all data until the server closes the connection.  At the same time, watch for errors on otherSocket.  Don't know how much is coming.  Put the data on the stream."

	| buf bytesRead |
	buf _ String new: 4000.
	[(self dataAvailable | self isConnected)] whileTrue: [
		(self waitForDataUntil: (Socket deadlineSecs: 5)) ifFalse: [
			otherSocket responseError ifTrue: [self destroy. ^ #error:].
			Transcript show: 'data was late'; cr].
		bytesRead _ self primSocket: socketHandle receiveDataInto: buf 
			startingAt: 1 count: buf size.
		1 to: bytesRead do: [:ii | dataStream nextPut: (buf at: ii)].
			"Any way to do this so we do not have to recopy?"
		].
	dataStream reset.	"position: 0."
	^ dataStream