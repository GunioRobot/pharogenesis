play

	| count |
	count _ ((2 * SoundPlayer samplingRate) // data size) max: 1.
	SampledSound defaultSamples: data repeated: count.
	SampledSound nominalSamplePitch: 250.
	Smalltalk garbageCollect.
	(SampledSound pitch: 440.0 dur: 1.5 loudness: 0.5) play.
