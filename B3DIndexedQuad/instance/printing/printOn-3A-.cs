printOn: aStream
	aStream nextPutAll:'IQuad(';
		print: (self at: 1);
		nextPutAll:', ';
		print: (self at: 2);
		nextPutAll:', ';
		print: (self at: 3);
		nextPutAll:', ';
		print: (self at: 4);
		nextPutAll:', ';
		print: (self flags);
		nextPutAll:')'.