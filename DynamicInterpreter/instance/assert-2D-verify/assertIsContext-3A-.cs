assertIsContext: t1 
	| t2 |
	self inline: false.
	self assertIsOop: t1.
	t2 _ self fetchClassOf: t1.
	(t2 == (self splObj: ClassBlockContext)
		or: [t2 == (self splObj: ClassMethodContext) or: [t2 == (self splObj: ClassPseudoContext)]])
		ifFalse: [self error: 'context expected']