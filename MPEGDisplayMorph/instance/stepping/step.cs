step
	"If I'm running and the mpegFile is open and has video, advance to the next frame. Stop if we we hit the end of the video."

	running ifFalse: [^ self].
	mpegFile ifNil: [^ self].

	(mpegFile hasVideo and:
	 [(mpegFile videoGetFrame: 0) >= (mpegFile videoFrames: 0)])
		ifTrue: [  "end of video"
			self stopPlaying.
			repeat ifTrue: [
				self rewindMovie.
				self startPlaying]]
		ifFalse: [self advanceFrame].
