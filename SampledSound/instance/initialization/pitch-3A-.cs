pitch: pitchNameOrNumber

	| p |
	p _ self nameOrNumberToPitch: pitchNameOrNumber.
	originalSamplingRate _
		((self samplingRate asFloat * p asFloat) / NominalSamplePitch asFloat) asInteger.
	self reset.
