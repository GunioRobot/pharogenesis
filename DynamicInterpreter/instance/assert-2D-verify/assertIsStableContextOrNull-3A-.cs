assertIsStableContextOrNull: t1 
	self inline: false.
	t1 == 0 ifFalse: [self assertIsOop: t1].
	(t1 == 0 or: [self isStableContext: t1])
		ifFalse: [self error: 'stable context or null expected']