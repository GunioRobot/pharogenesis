basicStoreVersion: aVersion
	(self allFileNames includes: aVersion fileName)
		ifFalse: [super basicStoreVersion: aVersion]
