printOn: aStream

	aStream
		nextPutAll: self class printString;
		nextPutAll: '>>';
		nextPutAll: self testMessage.