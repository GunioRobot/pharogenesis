setPitch: p dur: d loudness: vol
	"Used to play scores using the default sample table."
	"(SampledSound pitch: 880.0 dur: 1.5 loudness: 0.6) play"

	super setPitch: p dur: d loudness: vol.
	samples _ DefaultSampleTable.
	samplesSize _ samples size.
	initialCount _ (d * self samplingRate asFloat) rounded.
	originalSamplingRate _
		((self samplingRate asFloat * p asFloat) / NominalSamplePitch asFloat) asInteger.
	self setLoudness: vol.
	self reset.
