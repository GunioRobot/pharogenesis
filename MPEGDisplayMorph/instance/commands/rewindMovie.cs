rewindMovie
	"Rewind to the beginning of the movie."
	"Details: Seeking by percent or frame number both seem to have problems, so just re-open the file."

	| savedExtent savedRate |
	self mpegFileIsOpen ifFalse: [^ self].
	self stopPlaying.

	"re-open the movie, retaining current extent and frame rate"
	savedExtent _ self extent.
	savedRate _ desiredFrameRate.
	self openFileNamed: mpegFile fileName.  "recomputes rate and extent"
	self extent: savedExtent.
	desiredFrameRate _ savedRate.
