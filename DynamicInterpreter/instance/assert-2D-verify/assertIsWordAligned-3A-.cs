assertIsWordAligned: t1 
	self inline: false.
	t1 \\ 4 = 0 ifFalse: [self error: 'non-aligned word access']