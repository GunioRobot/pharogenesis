cacheFor: aClass 
	^perClassCache at: aClass ifAbsentPut: [self newCacheFor: aClass]