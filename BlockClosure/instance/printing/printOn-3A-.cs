printOn: aStream
	aStream nextPutAll: '[closure] in '.
	outerContext printOn: aStream