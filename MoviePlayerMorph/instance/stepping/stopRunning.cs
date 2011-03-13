stopRunning
	"Must only be called with no outstanding file read requests..."
	movieFile ifNotNil: [movieFile close.  movieFile := nil].
	playDirection := 0.
	self stopSoundTrackIfAny
