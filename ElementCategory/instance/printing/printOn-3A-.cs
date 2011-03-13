printOn: aStream
	"Append to the argument, aStream, a sequence of characters that identifies the receiver."

	super printOn: aStream.
	categoryName ifNotNil: [aStream nextPutAll: ' named ', categoryName asString]