cachedReceiverAt: cp

	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsOop: (self longAt: cp + (CacheReceiverIndex * 4)).
	^self longAt: cp + (CacheReceiverIndex * 4)