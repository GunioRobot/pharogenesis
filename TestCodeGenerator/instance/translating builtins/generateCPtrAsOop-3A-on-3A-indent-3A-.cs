generateCPtrAsOop: aNode on: aStream indent: anInteger

	aStream nextPutAll: '((int) ('.
	self emitCExpression: aNode receiver on: aStream.
	aStream nextPutAll: ') -4)'.