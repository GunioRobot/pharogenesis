getDataInto: dataStream
	"Reel in all data until the server closes the connection.  At the same time, watch for errors on otherSocket.  Don't know how much is coming.  Put the data on the stream."

	| buf bytesRead |
	buf _ String new: 4000.
	[self dataSocket isConnected or: [self dataSocket dataAvailable]]
		whileTrue: [
			self checkForPendingError.
			bytesRead _ self dataSocket receiveDataWithTimeoutInto: buf.
			1 to: bytesRead do: [:ii | dataStream nextPut: (buf at: ii)]].
	dataStream reset.	"position: 0."
	^ dataStream