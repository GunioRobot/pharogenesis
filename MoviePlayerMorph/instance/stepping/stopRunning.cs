stopRunning
	"Must only be called with no outstanding file read requests..."
	movieFile ifNotNil: [movieFile close.  movieFile _ nil].
	playDirection _ 0.
	self stopSoundTrackIfAny
