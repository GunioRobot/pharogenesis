basicStoreVersion: aVersion
	(aVersion isCacheable and: [self allFileNames includes: aVersion fileName])
		ifFalse: [super basicStoreVersion: aVersion]
