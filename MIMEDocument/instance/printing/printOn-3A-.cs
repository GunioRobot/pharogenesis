printOn: aStream
	aStream nextPutAll: self class name;
		nextPutAll: ' (';
		nextPutAll: self contentType;
		nextPutAll: ', ';
		nextPutAll: self content size printString;
		nextPutAll: ' bytes)'.