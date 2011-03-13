playUntilPosition: finalPosition
	"Play the movie until the given position, then stop."

	| totalFrames |
	totalFrames := self totalFrames.
	(totalFrames > 0 and: [finalPosition > 0]) ifFalse: [^ self].  "do nothing"
	self startPlaying.
	stopFrame := (finalPosition * totalFrames) asInteger min: totalFrames