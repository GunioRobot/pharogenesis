storeOn: aStream
	aStream
		nextPut: $(;
		nextPutAll: self class name;
		nextPutAll: ' collection: ';
		store: domain;
		nextPutAll: ' map: ';
		store: map;
		nextPut: $)