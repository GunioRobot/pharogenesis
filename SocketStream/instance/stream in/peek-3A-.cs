peek: anInteger
	"Answer anInteger bytes of data.
	Do not consume data.

	NOTE: This method doesn't honor timeouts if shouldSignal is false!"

	| start |
	self receiveData: anInteger.
	start _ lastRead + 1.
	^inBuffer copyFrom: start to: ((lastRead + anInteger) min: inNextToWrite - 1).