cachedInitialIPAt: cp put: anInteger

	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsIntegerObject: anInteger.
	self longAt: cp + (CacheInitialIPIndex * 4) put: anInteger