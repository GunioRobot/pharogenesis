next: anInteger
	"Answer anInteger bytes of data.

	NOTE: This method doesn't honor timeouts if shouldSignal is false!"

	| start |
	self receiveData: anInteger.
	start _ lastRead + 1.
	lastRead _ (lastRead + anInteger) min: inNextToWrite - 1.
	^inBuffer copyFrom: start to: lastRead