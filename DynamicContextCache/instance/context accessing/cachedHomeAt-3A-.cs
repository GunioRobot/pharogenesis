cachedHomeAt: cp

	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsContextOrNull: (self longAt: cp + (CacheHomeIndex * 4)).
	^self longAt: cp + (CacheHomeIndex * 4)