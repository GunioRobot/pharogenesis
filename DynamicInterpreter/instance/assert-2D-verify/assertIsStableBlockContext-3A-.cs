assertIsStableBlockContext: t1 
	self inline: false.
	self assertIsOop: t1.
	(self fetchClassOf: t1)
		== (self splObj: ClassBlockContext) ifFalse: [self error: 'stable BlockContext expected']