printOn: aStream
	aStream nextPut:$[.
	aStream print: nodeId.
	aStream nextPutAll:'] '.
	aStream nextPutAll: name.
	aStream nextPutAll:' {'.
	aStream cr.
	self attributes do:[:attr|
		attr printOn: aStream.
		aStream cr.
	].
	aStream nextPut:$}.