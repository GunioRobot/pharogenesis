assertIsLegalStackPointer: t1 
	self inline: false.
	self assertIsWordAligned: t1.
	t1 < (stackCache - 4) ifTrue: [self error: 'cached stack pointer is below the start of stack'].
	t1 >= self stackCacheLimit ifTrue: [self error: 'cached stack pointer is above the stack limit']