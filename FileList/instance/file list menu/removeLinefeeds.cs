removeLinefeeds
	"Remove any line feeds by converting to CRs instead"
	| fileContents |
	fileContents _ (CrLfFileStream readOnlyFileNamed: self fullName) contentsOfEntireFile.
	(StandardFileStream newFileNamed: self fullName) 
		nextPutAll: fileContents;
		close.