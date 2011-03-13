printOn: aStream
	"Append to the argument, aStream, a sequence of characters that   identifies the receiver."

	super printOn: aStream.
	vocabularyName ifNotNil: [aStream nextPutAll: ' named "', vocabularyName, '"']