cachedReceiverAt: cp put: anObject

	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsOop: anObject.
	self longAt: cp + (CacheReceiverIndex * 4) put: anObject