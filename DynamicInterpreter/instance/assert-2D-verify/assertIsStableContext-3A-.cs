assertIsStableContext: t1 
	| t2 |
	self inline: false.
	self assertIsOop: t1.
	t2 _ self fetchClassOf: t1.
	(t2 == (self splObj: ClassBlockContext) or: [t2 == (self splObj: ClassMethodContext)])
		ifFalse: [self error: 'stable context expected']