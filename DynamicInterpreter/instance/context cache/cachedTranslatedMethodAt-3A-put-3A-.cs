cachedTranslatedMethodAt: cp put: anArray

	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsTranslatedMethod: anArray.
	self longAt: cp + (CacheTranslatedMethodIndex * 4) put: anArray