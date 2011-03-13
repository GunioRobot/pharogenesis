printPrimitiveOn: aStream
	aStream nextPutAll: '<primitive: '; print: primitive.
	aStream nextPutAll: '>'