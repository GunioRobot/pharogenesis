printOn: aStream 
	super printOn: aStream.
	aStream nextPut: $[.
	selfSenders printOn: aStream.
	aStream nextPut: $|.
	superSenders printOn: aStream.
	aStream nextPut: $|.
	classSenders printOn: aStream.
	aStream nextPut: $]