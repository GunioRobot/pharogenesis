assertIsOop: t1 
	self inline: false.
	(self isIntegerObject: t1)
		ifFalse: [(self okayOop: t1)
				ifFalse: [self error: 'not a valid oop']]