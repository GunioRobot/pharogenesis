assertIsStableMethodContext: t1 
	self inline: false.
	self assertIsStableContext: t1.
	(self fetchClassOf: t1)
		== (self splObj: ClassMethodContext) ifFalse: [self error: 'stable method context expected']