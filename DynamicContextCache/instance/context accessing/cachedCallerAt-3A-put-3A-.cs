cachedCallerAt: cp put: aContext

	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsStableContextOrNil: aContext.
	self longAt: cp + (CacheCallerIndex * 4) put: aContext