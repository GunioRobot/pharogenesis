getAllDataWhileWatching: otherSocket
	"Reel in all data until the server closes the connection.  At the same time, watch for errors on otherSocket.  Return a RWBinaryOrTextStream.  Don't know how much is coming."

	| buf response bytesRead |
	buf _ String new: 4000.
	response _ RWBinaryOrTextStream on: (String new: 4000).
	[(self dataAvailable | self isConnected)] whileTrue: [
		(self waitForDataUntil: (Socket deadlineSecs: 5)) ifFalse: [
			otherSocket responseError ifTrue: [self destroy. ^ #error:].
			Transcript show: 'data was late'; cr].
		bytesRead _ self primSocket: socketHandle receiveDataInto: buf 
			startingAt: 1 count: buf size.
		1 to: bytesRead do: [:ii | response nextPut: (buf at: ii)].
			"Any way to do this so we do not have to recopy?"
		].
	response reset.	"position: 0."
	^ response