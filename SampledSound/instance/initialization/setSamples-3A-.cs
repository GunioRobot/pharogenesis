setSamples: anArray
	"There are two ways to use sampled sound: (a) you can play them through once (supported by this method) or (b) you can make them the default waveform with which to play a musical score (supported by the class method defaultSamplesFromAIFF:samplePitch:)."
	"(SampledSound new setSamples: SampledSound coffeeCupClink) play"

	self setSamples: anArray samplingRate: self samplingRate.
