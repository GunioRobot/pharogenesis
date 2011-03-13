playTest
	| synth |
	synth := KlattSynthesizer new.
	synth millisecondsPerFrame: 1000; cascade: 8.
	(SampledSound samples: (synth samplesFromFrames: {frame}) samplingRate: synth samplingRate) play