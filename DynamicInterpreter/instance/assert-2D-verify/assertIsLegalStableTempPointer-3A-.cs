assertIsLegalStableTempPointer: t1 
	| t2 t3 |
	self inline: false.
	self assertIsWordAligned: t1.
	t2 _ t1 - BaseHeaderSize - (TempFrameStart * 4).
	self assertIsOop: t2.
	self assertIsStableMethodContext: t2.
	t2 < youngStart
		ifTrue: 
			[t3 _ self longAt: t2.
			(t3 bitAnd: RootBit)
				== 0 ifTrue: [self error: 'old context is not a root']]