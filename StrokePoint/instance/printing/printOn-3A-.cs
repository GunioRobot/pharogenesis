printOn: aStream
	super printOn: aStream.
	aStream nextPut:$(; print: position; nextPut:$).