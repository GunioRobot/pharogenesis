printOn: aStream
	super printOn: aStream.
	aStream nextPutAll: ' (', self asOop printString, ')'