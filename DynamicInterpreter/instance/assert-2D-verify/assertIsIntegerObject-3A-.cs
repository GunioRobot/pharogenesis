assertIsIntegerObject: t1 
	self inline: false.
	(self isIntegerObject: t1)
		ifFalse: [self error: 'integer object expected']