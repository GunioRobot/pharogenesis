cachedInitialIPAt: cp

	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsIntegerObject: (self longAt: cp + (CacheInitialIPIndex * 4)).
	^self longAt: cp + (CacheInitialIPIndex * 4)