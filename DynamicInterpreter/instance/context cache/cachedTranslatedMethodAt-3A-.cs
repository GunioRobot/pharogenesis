cachedTranslatedMethodAt: cp

	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsTranslatedMethod: (self longAt: cp + (CacheTranslatedMethodIndex * 4)).
	^self longAt: cp + (CacheTranslatedMethodIndex * 4)