initialize
	"initialize the state of the receiver"
	super initialize.""
	super extent: 250 @ 0.
	frameBuffer := nil.
	mpegFile := nil.
	running := false.
	desiredFrameRate := 10.0.
	allowFrameDropping := true.
	repeat := false.
	soundTrack := nil.
	volume := 0.5.
	fullScreen := false.
""
self initializeSubtitlesDisplayer