printOn: aStream
	super printOn: aStream.
	aStream cr;
		nextPutAll: ' familyName: ', familyName asString;cr;
		nextPutAll: ' emphasis: ', emphasis asString;cr;
		nextPutAll: ' pointSize: ', pointSize asString;cr;
		nextPutAll: ' realFont: ', realFont asString;
		nextPutAll: ' weight: ', weightValue asString;
		nextPutAll: ' stretch: ', stretchValue asString;
		nextPutAll: ' slant: ', slantValue asString.