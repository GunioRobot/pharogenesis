assertIsLegalStackOffsetInContext: t1 
	| t2 t3 |
	self inline: false.
	t2 _ self fetchWord: StackPointerIndex ofObject: t1.
	self assertIsIntegerObject: t2.
	t2 _ self integerValueOf: t2.
	t3 _ (self sizeBitsOf: t1)
				- BaseHeaderSize - (TempFrameStart * 4).
	t2 >= t3 ifTrue: [self error: 'illegal stack pointer in stable context']