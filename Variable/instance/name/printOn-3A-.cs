printOn: aStream
	"Print the receiver on the stream"

	super printOn: aStream.
	aStream nextPutAll: ' named ', (self variableName ifNil: ['<unnamed>']), ' type = ', variableType printString, ' default val = ', defaultValue printString