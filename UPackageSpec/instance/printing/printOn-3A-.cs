printOn: aStream
	aStream
		nextPutAll: name;
		nextPutAll: '/';
		print: version