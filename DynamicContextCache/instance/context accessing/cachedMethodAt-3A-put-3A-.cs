cachedMethodAt: cp put: aCompiledMethod

	self inline: true.
	self assertIsCachedContext: cp.
	self assertIsCompiledMethod: aCompiledMethod.
	self longAt: cp + (CacheMethodIndex * 4) put: aCompiledMethod