assertIsArray: t1 
	self inline: false.
	self assertIsOop: t1.
	(self fetchClassOf: t1)
		== (self splObj: ClassArray) ifFalse: [self error: 'Array expected']