assertIsNotNull: t1 
	self inline: false.
	t1 == 0 ifTrue: [self error: 'non-null expected']