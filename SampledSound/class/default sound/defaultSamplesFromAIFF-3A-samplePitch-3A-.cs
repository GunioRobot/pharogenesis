defaultSamplesFromAIFF: fileName samplePitch: aNumber
	"Set the sample table to be used as the default waveform from the AIFF file of the given name. The sample pitch is an estimate of the normal pitch of the sampled sound."
	"SampledSound defaultSamplesFromAIFF: 'boing.aiff' samplePitch: 200"

	self defaultSampleTable: (self fromAIFFfileNamed: fileName) samples.
	self nominalSamplePitch: aNumber.
