assertIsCachedBlockContext: t1 
	self inline: false.
	(self isCachedBlockContext: t1)
		ifFalse: [self error: 'cached block context expected']