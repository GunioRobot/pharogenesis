assertIsLegalTranslatedInstructionIndex: t1 in: t2 
	| t3 |
	self inline: false.
	self assertIsIntegerObject: t1.
	t3 _ self integerValueOf: t1.
	t3 < (BaseHeaderSize + 1) ifTrue: [self error: 'ip points before first instruction'].
	t3 > ((self sizeBitsOf: t2)
			- BaseHeaderSize) ifTrue: [self error: 'ip points after last instruction']