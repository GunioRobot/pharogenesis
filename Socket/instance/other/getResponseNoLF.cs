getResponseNoLF
	"Get the response to the last command."

	| buf response bytesRead c lf |
	(self waitForDataUntil: (Socket deadlineSecs: 20)) ifFalse: [
		self error: 'getResponse timeout'].
	lf _ Character lf.
	buf _ String new: 1000.
	response _ WriteStream on: ''.
	[self dataAvailable] whileTrue: [
		bytesRead _ self primSocket: socketHandle receiveDataInto: buf startingAt: 1 count: buf size.
		1 to: bytesRead do: [ :i |
			(c _ buf at: i) ~= lf ifTrue: [response nextPut: c]]].

	^ response contents
