assertIsPseudoContextOrNull: t1 
	self inline: false.
	t1 == 0 ifFalse: [self assertIsOop: t1].
	(t1 == 0 or: [(self fetchClassOf: t1)
			== (self splObj: ClassPseudoContext)])
		ifFalse: [self error: 'PseudoContext expected']