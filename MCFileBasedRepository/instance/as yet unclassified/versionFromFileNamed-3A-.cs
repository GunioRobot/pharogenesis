versionFromFileNamed: aString
	cache ifNil: [cache _ Dictionary new].
	^ cache at: aString ifAbsentPut: [self loadVersionFromFileNamed: aString]