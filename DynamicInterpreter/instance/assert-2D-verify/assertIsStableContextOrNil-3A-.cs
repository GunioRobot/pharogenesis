assertIsStableContextOrNil: t1 
	self inline: false.
	self assertIsOop: t1.
	(t1 == nilObj or: [self isStableContext: t1])
		ifFalse: [self error: 'stable context or null expected']