printOn: aStream 
	self origin printOn: aStream.
	aStream nextPutAll: '->'.
	self opposite origin printOn: aStream.	