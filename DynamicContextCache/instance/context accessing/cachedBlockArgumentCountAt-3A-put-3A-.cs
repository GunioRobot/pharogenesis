cachedBlockArgumentCountAt: cp put: anInteger

	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsIntegerObject: anInteger.
	self longAt: cp + (CacheBlockArgumentCountIndex * 4) put: anInteger