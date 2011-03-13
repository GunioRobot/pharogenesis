measureMaxFrameRate
	"For testing. Play through the movie as fast as possible, updating the world each time, and report the frame rate."

	| oldFrameRate oldFrameDropping t |
	self rewindMovie.
	oldFrameRate := desiredFrameRate.
	oldFrameDropping := allowFrameDropping.
	desiredFrameRate := 1000.0.
	allowFrameDropping := false.

	self startPlaying.
	t := [[running] whileTrue: [self world doOneCycleNow]] timeToRun.

	desiredFrameRate := oldFrameRate.
	allowFrameDropping := oldFrameDropping.

	^ (mpegFile videoFrames: 0) / (t / 1000.0)
