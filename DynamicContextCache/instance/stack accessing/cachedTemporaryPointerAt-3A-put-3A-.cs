cachedTemporaryPointerAt: cp put: tp
	self inline: true.
	self assertIsCachedContext: cp.
	^self longAt: cp + (CacheTempPointerIndex * 4) put: tp