assertIsLegalInstructionPointer: t1 in: t2 
	self inline: false.
	t1 < (t2 + BaseHeaderSize + 4 - 1) ifTrue: [self error: 'ip points before first bytecode'].
	t1 > (t2 + (self sizeBitsOf: t2) - 1) ifTrue: [self error: 'ip points after last bytecode']