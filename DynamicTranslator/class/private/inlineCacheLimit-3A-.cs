inlineCacheLimit: newLimit
	| oldLimit |
	oldLimit _ Smalltalk vmParameterAt: 19 put: newLimit.
	Object flushCache.
	^oldLimit