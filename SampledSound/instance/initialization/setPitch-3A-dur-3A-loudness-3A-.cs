setPitch: pitchNameOrNumber dur: d loudness: vol
	"Used to play scores using the default sample table."
	"(SampledSound pitch: 880.0 dur: 1.5 loudness: 0.6) play"

	| p |
	super setPitch: pitchNameOrNumber dur: d loudness: vol.
	p _ self nameOrNumberToPitch: pitchNameOrNumber.
	samples _ DefaultSampleTable.
	samplesSize _ samples size.
	initialCount _ (d * self samplingRate asFloat) rounded.
	originalSamplingRate _
		((self samplingRate asFloat * p asFloat) / NominalSamplePitch asFloat) asInteger.
	self loudness: vol.
	self reset.
