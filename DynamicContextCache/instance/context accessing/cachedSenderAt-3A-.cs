cachedSenderAt: cp

	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsStableContextOrNilOrNull: (self longAt: cp + (CacheSenderIndex * 4)).
	^self longAt: cp + (CacheSenderIndex * 4)