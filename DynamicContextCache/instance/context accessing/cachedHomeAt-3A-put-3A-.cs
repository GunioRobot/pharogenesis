cachedHomeAt: cp put: aContext

	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsContextOrNull: aContext.
	self longAt: cp + (CacheHomeIndex * 4) put: aContext.
"
	self cachedTemporaryPointerAt: cp put: (self temporaryPointerForCachedContext: aContext).
"