playSilently
	"Compute the samples of this sound without outputting them. Used for performance analysis."

	| bufSize buf |
	self reset.
	bufSize _ self samplingRate // 10.
	buf _ SoundBuffer newStereoSampleCount: bufSize.
	[self samplesRemaining > 0] whileTrue: [
		buf primFill: 0.
		self playSampleCount: bufSize into: buf startingAt: 1].
