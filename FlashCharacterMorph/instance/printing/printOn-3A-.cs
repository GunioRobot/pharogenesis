printOn: aStream
	super printOn: aStream.
	aStream
		nextPutAll:'(renderTime = '; print: renderTime;
		nextPutAll:'; depth = '; print: self depth;
		"nextPutAll:' complexity = '; print: self complexity * bounds area // 1000 / 1000.0;"
		"nextPutAll:' size = '; print: bounds area;"
	 nextPutAll:')'.