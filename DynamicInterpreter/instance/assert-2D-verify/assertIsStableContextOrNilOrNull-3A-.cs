assertIsStableContextOrNilOrNull: t1 
	self inline: false.
	t1 == 0
		ifFalse: 
			[(t1 == nilObj or: [self isStableContext: t1])
				ifFalse: [self error: 'stable context or null expected'].
			self assertIsOop: t1]