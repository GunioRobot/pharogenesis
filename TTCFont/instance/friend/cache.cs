cache

	(cache at: 1) ifNil: [self flushCache].
	^ cache at: 1.
