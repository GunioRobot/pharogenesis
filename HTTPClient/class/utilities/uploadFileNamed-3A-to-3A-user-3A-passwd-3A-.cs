uploadFileNamed: aFilename to: baseUrl user: user passwd: passwd

	| fileContents remoteFilename |
	remoteFilename _ (baseUrl endsWith: '/')
		ifTrue: [baseUrl , '/' , aFilename]
		ifFalse: [baseUrl , aFilename].
	fileContents _ (StandardFileStream readOnlyFileNamed: aFilename) contentsOfEntireFile.
	HTTPSocket httpPut: fileContents to: remoteFilename user: user passwd: passwd