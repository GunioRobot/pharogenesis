storeOn: aStream

	self isTransparent ifTrue: [^ aStream nextPutAll: '(Color transparent)'].
	super storeOn: aStream.
	aStream
		skip: -1;	  "get rid of trailing )"
		nextPutAll: ' alpha: ';
		nextPutAll: self alpha printString;
		nextPutAll: ')'.
