closeFile
	"Close my MPEG file, if any."

	mpegFile isNil
		ifFalse: [
			mpegFile closeFile.
			mpegFile := nil.
			frameBuffer := nil].

	subtitles := nil.
	self changed.
