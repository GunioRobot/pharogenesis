assertIsLegalCachedTempPointer: t1 
	self inline: false.
	self assertIsWordAligned: t1.
	t1 < stackCache ifTrue: [self error: 'cached temporary pointer is below the start of stack'].
	t1 > stackCacheFence ifTrue: [self error: 'cached temporary pointer is above the stack fence']