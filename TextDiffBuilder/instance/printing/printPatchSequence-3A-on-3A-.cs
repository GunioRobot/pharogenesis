printPatchSequence: seq on: aStream 
	seq do: 
		[:assoc | 
		aStream
			withAttribute: (self attributeOf: assoc key)
			do: [aStream nextPutAll: assoc value; cr]]