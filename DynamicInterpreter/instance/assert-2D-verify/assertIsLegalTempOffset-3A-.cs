assertIsLegalTempOffset: t1 
	| t2 |
	self inline: false.
	t1 < 0 ifTrue: [self error: 'negative temp offset'].
	self assertIsLegalTempPointer: self temporaryPointer.
	self temporaryPointer > contextCache
		ifTrue: [(t1 < 0 or: [t1 > 31])
				ifTrue: [self error: 'illegal cached temp offset']]
		ifFalse: 
			[t2 _ self sizeBitsOf: self temporaryPointer - BaseHeaderSize - (TempFrameStart * 4).
			t2 _ t2 - BaseHeaderSize // 4 - TempFrameStart.
			t1 >= t2 ifTrue: [self error: 'stable temp offset too large']]