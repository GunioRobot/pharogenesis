printOn: aStream
	aStream nextPutAll: self class name;
		nextPut:$(;
		print: start;
		nextPut:$-;
		print: stop;
		nextPutAll:' -> ';
		print: data;
		nextPut:$)