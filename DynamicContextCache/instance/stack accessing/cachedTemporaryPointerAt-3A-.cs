cachedTemporaryPointerAt: cp
	self inline: true.
	^self longAt: cp + (CacheTempPointerIndex * 4)