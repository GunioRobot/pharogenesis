measureMaxFrameRate
	"For testing. Play through the movie as fast as possible, updating the world each time, and report the frame rate."

	| oldFrameRate oldFrameDropping t |
	self rewindMovie.
	oldFrameRate _ desiredFrameRate.
	oldFrameDropping _ allowFrameDropping.
	desiredFrameRate _ 1000.0.
	allowFrameDropping _ false.

	self startPlaying.
	t _ [[running] whileTrue: [self world doOneCycleNow]] timeToRun.

	desiredFrameRate _ oldFrameRate.
	allowFrameDropping _ oldFrameDropping.

	^ (mpegFile videoFrames: 0) / (t / 1000.0)
