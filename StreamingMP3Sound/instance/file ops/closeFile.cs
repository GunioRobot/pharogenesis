closeFile
	"Close the MP3 or MPEG file."

	self pause.
	mpegFile ifNil: [^ self].
	mpegFile closeFile.
	mpegFile _ nil.
	mixer _ nil.
