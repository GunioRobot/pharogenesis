printOn: aStream
	aStream
		nextPutAll: self class name;
		nextPut: $(;
		nextPutAll: self xid hex;
		nextPut: $) 