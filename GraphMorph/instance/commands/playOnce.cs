playOnce

	SampledSound defaultSamples: data repeated: 1.
	SampledSound nominalSamplePitch: 250.
	Smalltalk garbageCollect.
	(SampledSound pitch: 440.0 dur: 1.5 loudness: 0.5) play.
