printOn: aStream
	aStream 
		print: self class;
		nextPutAll: ' (';
		print: package;
		nextPutAll: ')'