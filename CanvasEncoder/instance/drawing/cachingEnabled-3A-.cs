cachingEnabled: aBoolean

	(cachingEnabled _ aBoolean) ifFalse: [
		cachedObjects _ nil.
	].
