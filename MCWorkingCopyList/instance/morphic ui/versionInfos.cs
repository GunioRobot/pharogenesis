versionInfos
	^ workingCopy
		ifNil: [#()]
		ifNotNil: [self packageCache versionInfos]