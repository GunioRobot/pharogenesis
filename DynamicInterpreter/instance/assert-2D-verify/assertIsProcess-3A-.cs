assertIsProcess: t1 
	self inline: false.
	self assertIsOop: t1.
	(self fetchClassOf: t1)
		= (self splObj: ClassProcess) ifFalse: [self error: 'process expected']