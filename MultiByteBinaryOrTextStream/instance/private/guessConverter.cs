guessConverter
	^ (self originalContents includesSubString: (ByteArray withAll: {27. 36}) asString)
		ifTrue: [CompoundTextConverter new]
		ifFalse: [self class defaultConverter ]