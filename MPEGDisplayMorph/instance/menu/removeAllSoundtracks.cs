removeAllSoundtracks
	"Remove all soundtracks from this JPEG movie."

	(mpegFile isKindOf: JPEGMovieFile) ifFalse: [^ self].  "do nothing if not a JPEG movie"

	mpegFile closeFile.
	JPEGMovieFile removeSoundtrackFromJPEGMovieNamed: mpegFile fileName.
	self openFileNamed: mpegFile fileName.
