printOn: aStream
	aStream
		nextPutAll: name;
		nextPutAll: ' version ';
		print: version