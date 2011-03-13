cacheAllFileNamesDuring: aBlock
	allFileNames := self allFileNames.
	^ aBlock ensure: [allFileNames := nil]