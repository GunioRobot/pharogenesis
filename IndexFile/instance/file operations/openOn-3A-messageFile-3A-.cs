openOn: aFileName messageFile: messageFile 
	"Initialize myself from the file with the given name."
	| fileStream |
	filename _ aFileName.
	fileStream _ FileStream fileNamed: aFileName.
	self readFrom: (ReadStream on: fileStream contentsOfEntireFile)
		messageFile: messageFile.
	self readLogMessageFile: messageFile .
	"close and release the file stream"
	fileStream _ nil