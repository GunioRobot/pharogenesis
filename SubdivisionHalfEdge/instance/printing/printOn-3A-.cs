printOn: aStream

	aStream
		nextPutAll: self class name;
		nextPut:$(;
		print: (self origin);
		nextPut:$/;
		print: self destination;
		nextPut:$);
		yourself