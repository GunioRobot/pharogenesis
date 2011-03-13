install
	self url ifNil: [^ self].
	UPackageInstaller installFileNamed: self cachedCopyFilename