processIO
	"should be called periodically--this actually sends and recieves some bytes over the network"
	| amountSent |


	self isConnected ifFalse: [ ^ self ].

	outputBuffer _ outputBuffer contents.	"convert to String for convenience in the loop.  still not as optimal as it could be...."
	[outputBuffer size > 0 and: [ socket sendDone ]] whileTrue: [ 
		"do some output"
		amountSent _ socket sendSomeData: outputBuffer.
		outputBuffer _ outputBuffer copyFrom: amountSent+1 to: outputBuffer size. ].
	outputBuffer _ WriteStream on: outputBuffer.

	"do some input"
	[socket dataAvailable] whileTrue: [
		self processInput: socket getData ].