printOn: aStream
	aStream nextPutAll: self class name; nextPutAll: ' ('; nextPutAll: self name; nextPut: $)