version
	^ version ifNil: [version _ repository versionWithInfo: selectedVersion]