assertIsCachedMethodContext: t1 
	self inline: false.
	(self isCachedMethodContext: t1)
		ifFalse: [self error: 'cached method context expected']