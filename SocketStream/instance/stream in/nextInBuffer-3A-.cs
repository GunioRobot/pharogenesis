nextInBuffer: anInteger
	"Answer anInteger bytes of data at most,
	but only from the inBuffer."

	| start amount |
	amount _ anInteger min: (inNextToWrite - lastRead - 1).
	start _ lastRead + 1.
	lastRead _ lastRead + amount.
	^inBuffer copyFrom: start to: lastRead