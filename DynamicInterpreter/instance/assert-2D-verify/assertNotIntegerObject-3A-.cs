assertNotIntegerObject: t1 
	self inline: false.
	(self isIntegerObject: t1)
		ifTrue: [self error: 'integer object unexpected']