millisecondsSinceStart
	"Answer the number of milliseconds of this sound started playing."

	| mSecs |
	(stream isNil or: [stream closed]) ifTrue: [^ 0].
	mSecs _ self currentSampleIndex * 1000 // streamSamplingRate.
	(self isPlaying and: [lastBufferMSecs > 0]) ifTrue: [
		"adjust mSecs by the milliseconds since the last buffer"
		mutex critical: [
			mSecs _ self currentSampleIndex * 1000 // streamSamplingRate.
			mSecs _ mSecs + ((Time millisecondClockValue - lastBufferMSecs) max: 0)]].
	^ mSecs + 350 - (2 * SoundPlayer bufferMSecs)
