writeToFileNamed: aFileName prependingFileNamed: anotherFileName
	| stream |
	"Catch attempts to overwrite existing zip file"
	(self canWriteToFileNamed: aFileName)
		ifFalse: [ ^self error: (aFileName, ' is needed by one or more members in this archive') ].
	stream _ StandardFileStream forceNewFileNamed: aFileName.
	self writeTo: stream prependingFileNamed: anotherFileName.
	stream close.