detect: aBlock
	self detect: aBlock ifNone: [self error: 'event not found']