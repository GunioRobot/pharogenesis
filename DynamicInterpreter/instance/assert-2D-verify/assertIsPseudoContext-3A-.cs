assertIsPseudoContext: t1 
	self inline: false.
	self assertIsOop: t1.
	(self fetchClassOf: t1)
		== (self splObj: ClassPseudoContext) ifFalse: [self error: 'PseudoContext expected']