assertIsStableContextClass: t1 
	self inline: false.
	self assertIsOop: t1.
	(t1 == (self splObj: ClassMethodContext) or: [t1 == (self splObj: ClassBlockContext)])
		ifFalse: [self error: 'stable context class expected']