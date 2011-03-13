advanceFrame
	"Advance to the next frame if it is time to do so, skipping frames if necessary."

	| msecs currentFrame desiredFrame framesToAdvance |
	mpegFile hasVideo ifFalse: [^ self].
	soundTrack
		ifNil: [msecs := Time millisecondClockValue - startMSecs]
		ifNotNil: [msecs := soundTrack millisecondsSinceStart - SoundPlayer bufferMSecs].
	desiredFrame := startFrame + ((msecs * desiredFrameRate) // 1000) + 1.
	desiredFrame := desiredFrame min: (mpegFile videoFrames: 0).
	currentFrame := mpegFile videoGetFrame: 0.
	stopFrame ifNotNil:
		[desiredFrame := desiredFrame min: stopFrame.
		currentFrame >= stopFrame ifTrue: [^ self stopPlaying]].
	framesToAdvance := desiredFrame - currentFrame.
	framesToAdvance <= 0 ifTrue: [^ self].
	(allowFrameDropping and: [framesToAdvance > 1]) ifTrue:
		[mpegFile videoDropFrames: framesToAdvance - 1 stream: 0].
	self nextFrame