playSilently
	"Compute the samples of this sound without outputting them. Used for performance analysis."

	| buf |
	self reset.
	buf _ SoundBuffer sampleCount: (self samplingRate // 10).
	[self samplesRemaining > 0] whileTrue: [
		buf primFill: 0.
		self playSampleCount: buf sampleCount into: buf startingAt: 1 stereo: true.
	].
