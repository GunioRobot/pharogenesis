printOn: aStream
	aStream 
		nextPutAll: self class name;
		nextPut:$<;
		print: myName;
		nextPut:$>.