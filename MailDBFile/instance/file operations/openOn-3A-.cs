openOn: aFileName
	"Initialize myself from the file with the given name."

	| fileStream |
	filename _ aFileName.
	fileStream _ FileStream fileNamed: aFileName.
	self readFrom: fileStream.
	fileStream setToEnd; close; release.
		"close and release the file stream"
	fileStream _ nil.