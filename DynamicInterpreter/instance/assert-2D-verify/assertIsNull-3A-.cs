assertIsNull: t1 
	self inline: false.
	t1 == 0 ifFalse: [self error: 'null expected']