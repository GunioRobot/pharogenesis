assertIsLegalTempPointer: t1 
	self inline: false.
	t1 >= contextCache
		ifTrue: [self assertIsLegalCachedTempPointer: t1]
		ifFalse: [self assertIsLegalStableTempPointer: t1]