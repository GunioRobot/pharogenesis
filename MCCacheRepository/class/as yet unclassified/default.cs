default
	self checkCacheDirectory.
	^ default ifNil: [default _ self new directory: self cacheDirectory]