printOn: aStream
	aStream nextPutAll: self class name.
	aStream nextPutAll: ' runs: '.
	runs printOn: aStream.
	aStream nextPutAll: ' values: '.
	values printOn: aStream.
