cachedBlockArgumentCountAt: cp

	self inline: true.
	self assertIsCachedContext: cp.
	^self longAt: cp + (CacheBlockArgumentCountIndex * 4)