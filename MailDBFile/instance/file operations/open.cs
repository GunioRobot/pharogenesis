open
	"read in my data initially"
	| fileStream |
	fileStream _ self fileStream.
	self readFrom: fileStream.
	fileStream setToEnd; close; release.
		"close and release the file stream"
	fileStream _ nil.
	self updateSizeAndModTime.