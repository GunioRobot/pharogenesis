nextPutAll: aString
	"add an entire string with the same attributes"
	currentRun _ currentRun + aString size.
	characters nextPutAll: aString.