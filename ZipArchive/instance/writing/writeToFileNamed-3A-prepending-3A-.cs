writeToFileNamed: aFileName prepending: aString
	| stream |
	"Catch attempts to overwrite existing zip file"
	(self canWriteToFileNamed: aFileName)
		ifFalse: [ ^self error: (aFileName, ' is needed by one or more members in this archive') ].
	stream _ StandardFileStream forceNewFileNamed: aFileName.
	self writeTo: stream prepending: aString.
	stream close.