setPitch: pitchNameOrNumber dur: d loudness: vol

	| p sz |
	super setPitch: pitchNameOrNumber dur: d loudness: vol.
	p _ self nameOrNumberToPitch: pitchNameOrNumber.
	initialCount _ (d * self samplingRate asFloat) asInteger.
	ring _ SoundBuffer newMonoSampleCount:
		(((2.0 * self samplingRate) / p) asInteger max: 2).
	sz _ ring monoSampleCount.
	scaledIndexLimit _ (sz + 1) * ScaleFactor.
	scaledIndexIncr _ (p * sz * ScaleFactor) // (2.0 * self samplingRate).
	self reset.
