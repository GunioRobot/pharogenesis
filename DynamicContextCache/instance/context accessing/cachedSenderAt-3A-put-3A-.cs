cachedSenderAt: cp put: aContext

	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsStableContextOrNilOrNull: aContext.			"nil if base context"
	self longAt: cp + (CacheSenderIndex * 4) put: aContext