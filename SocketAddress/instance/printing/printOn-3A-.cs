printOn: aStream

	aStream
		nextPutAll: self hostNumber;
		nextPut: $(; nextPutAll: self hostName; nextPut: $);
		nextPut: $,;
		nextPutAll: self serviceNumber;
		nextPut: $(; nextPutAll: self serviceName; nextPut: $)