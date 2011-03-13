printOn: aStream
	aStream nextPutAll: selector printString, '->'. 
	metaNode shortPrintOn: aStream.