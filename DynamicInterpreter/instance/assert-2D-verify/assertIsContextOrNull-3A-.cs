assertIsContextOrNull: t1 
	| t2 |
	self inline: false.
	t1 = 0
		ifFalse: 
			[self assertIsOop: t1.
			t2 _ self fetchClassOf: t1.
			(t2 == (self splObj: ClassBlockContext)
				or: [t2 == (self splObj: ClassMethodContext) or: [t2 == (self splObj: ClassPseudoContext)]])
				ifFalse: [self error: 'context expected']]