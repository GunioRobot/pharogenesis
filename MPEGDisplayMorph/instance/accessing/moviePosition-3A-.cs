moviePosition: fraction
	"Jump to the position the given fraction through the movie. The argument is a number between 0.0 and 1.0."

	| frameCount frameIndex |
	self mpegFileIsOpen ifFalse: [^ self].
	self stopPlaying.
	mpegFile hasVideo ifTrue: [
		frameCount _ mpegFile videoFrames: 0.
		frameIndex _ (frameCount * fraction) truncated - 1.
		frameIndex _ (frameIndex max: 0) min: (frameCount - 3).
		mpegFile videoSetFrame: frameIndex stream: 0.
		^ self nextFrame].

	mpegFile hasAudio ifTrue: [
		soundTrack soundPosition: fraction].
