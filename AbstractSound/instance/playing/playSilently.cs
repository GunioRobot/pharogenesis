playSilently
	"Compute the samples of this sound without outputting them. Used for performance analysis."

	| buf |
	self reset.
	buf _ SoundBuffer newStereoSampleCount: (self samplingRate // 10).
	[self samplesRemaining > 0] whileTrue: [
		buf primFill: 0.
		self playSampleCount: buf stereoSampleCount into: buf startingAt: 1].
