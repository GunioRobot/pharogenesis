printOn: aStream
	super printOn: aStream.
	aStream 
		nextPut: $(;
		print: hashKey; space; print: hashLock;
		nextPut: $).