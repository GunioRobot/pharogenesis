cachedMethodAt: cp

	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsCompiledMethod: (self longAt: cp + (CacheMethodIndex * 4)).
	^self longAt: cp + (CacheMethodIndex * 4)