get: limit dataInto: dataStream
	"Reel in data until the server closes the connection or the limit is reached.
	At the same time, watch for errors on otherSocket."

	| buf bytesRead currentlyRead |
	currentlyRead _ 0.
	buf _ String new: 4000.
	[currentlyRead < limit and: 
	[self dataSocket isConnected or: [self dataSocket dataAvailable]]]
		whileTrue: [
			self checkForPendingError.
			bytesRead _ self dataSocket receiveDataWithTimeoutInto: buf.
			1 to: (bytesRead min: (limit - currentlyRead)) do: [:ii | dataStream nextPut: (buf at: ii)].
			currentlyRead _ currentlyRead + bytesRead].
	dataStream reset.	"position: 0."
	^ dataStream