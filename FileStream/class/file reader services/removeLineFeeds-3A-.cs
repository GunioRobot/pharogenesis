removeLineFeeds: fullName
	| fileContents |
	fileContents _ ((FileStream readOnlyFileNamed: fullName) wantsLineEndConversion: true) contentsOfEntireFile.
	(FileStream newFileNamed: fullName) 
		nextPutAll: fileContents;
		close.