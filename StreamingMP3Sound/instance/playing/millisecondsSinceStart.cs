millisecondsSinceStart
	"Answer the number of milliseconds since this sound started playing."

	| i mSecs |
	mpegFile ifNil: [^ 0].
	mpegFile fileHandle ifNil: [^ 0].  "mpeg file not open"
	i _ mpegFile audioGetSample: mpegStreamIndex.
	i < 0 ifTrue: [^ 0].  "movie file has no audio"
	mSecs _ i * 1000 // streamSamplingRate.
	(self isPlaying and: [lastBufferMSecs > 0]) ifTrue: [
		"adjust mSecs by the milliseconds since the last buffer"
		mutex critical: [
			mSecs _ i * 1000 // streamSamplingRate.
			mSecs _ mSecs + ((Time millisecondClockValue - lastBufferMSecs) max: 0)]].
	^ mSecs + 350 - (2 * SoundPlayer bufferMSecs)
