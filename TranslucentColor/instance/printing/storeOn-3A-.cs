storeOn: aStream

	super storeOn: aStream.
	aStream
		skip: -1;	  "get rid of trailing )"
		nextPutAll: ' alpha: ';
		nextPutAll: alpha printString;
		nextPutAll: ')'.
