playSilentlyUntil: startTime
	"Compute the samples of this sound without outputting them. Used to fast foward to a particular starting time. The start time is given in seconds."

	| buf startSample nextSample samplesRemaining n |
	self reset.
	buf _ SoundBuffer newStereoSampleCount: (self samplingRate // 10).
	startSample _ (startTime * self samplingRate) asInteger.
	nextSample _ 1.
	[self samplesRemaining > 0] whileTrue: [
		nextSample >= startSample ifTrue: [^ self].
		samplesRemaining _ startSample - nextSample.
		samplesRemaining > buf stereoSampleCount
			ifTrue: [n _ buf stereoSampleCount]
			ifFalse: [n _ samplesRemaining].
		self playSampleCount: n into: buf startingAt: 1.
		nextSample _ nextSample + n].
