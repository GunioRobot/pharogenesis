discardReceivedData
	"Discard any data received up until now, and return the number of bytes discarded."

	| buf totalBytesDiscarded |
	buf _ String new: 10000.
	totalBytesDiscarded _ 0.
	[self isConnected] whileTrue: [
		totalBytesDiscarded _
			totalBytesDiscarded + (self receiveDataInto: buf)].
	^ totalBytesDiscarded
