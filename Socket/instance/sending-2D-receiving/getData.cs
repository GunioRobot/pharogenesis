getData
	"Get some data"

	| buf bytesRead |
	(self waitForDataUntil: Socket standardDeadline) ifFalse: [self error: 'getData timeout'].
	buf _ String new: 4000.
	bytesRead _ self primSocket: socketHandle receiveDataInto: buf startingAt: 1 count: buf size.
	^ buf copyFrom: 1 to: bytesRead