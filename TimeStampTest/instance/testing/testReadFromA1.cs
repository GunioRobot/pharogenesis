testReadFromA1
	|ts|
	ts _ TimeStamp current.
	self assert: (ts = (TimeStamp fromString: ts asString)).