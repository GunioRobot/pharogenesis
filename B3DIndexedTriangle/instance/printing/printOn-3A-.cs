printOn: aStream
	aStream nextPutAll:'IFace(';
		print: self p1Index;
		nextPutAll:', ';
		print: self p2Index;
		nextPutAll:', ';
		print: self p3Index;
		nextPutAll:', ';
		print: self flags;
		nextPutAll:')'.