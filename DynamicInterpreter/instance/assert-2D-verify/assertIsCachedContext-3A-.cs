assertIsCachedContext: t1 
	self inline: false.
	(t1 < contextCache
		or: [t1 > lastCachedContext or: [t1 - contextCache \\ CacheEntrySize ~= 0]])
		ifTrue: [self error: 'cached context pointer expected']