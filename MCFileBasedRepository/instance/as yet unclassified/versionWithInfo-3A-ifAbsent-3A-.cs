versionWithInfo: aVersionInfo ifAbsent: errorBlock
	| version |
	(self allFileNamesForVersionNamed: aVersionInfo name) do:
		[:fileName |
		version := self versionFromFileNamed: fileName.
		version info = aVersionInfo ifTrue: [^ version]].
	^ errorBlock value