generateStSize: aNode on: aStream indent: anInteger

	aStream nextPutAll: 'interpreterProxy->stSizeOf('.
	self emitCExpression: aNode receiver on: aStream.
	aStream nextPutAll: ')'.