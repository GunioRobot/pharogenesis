playTestNote

	| data end snd loopDur dur |
	(loopEnd = 0 or: [loopLength = 0]) ifTrue: [^ self].
	data _ graph data.
	end _ (loopEnd min: data size) max: 1.
	snd _ LoopedSampledSound new
		samples: data loopEnd: end loopLength: loopLength
		pitch: 100.0 samplingRate: samplingRate.

	loopDur _ (4.0 * loopLength / samplingRate) max: 2.0.  "longer of 4 loops or 2 seconds"
	dur _ (data size / samplingRate) + loopDur.
	(snd
		addReleaseEnvelope;
		setPitch: 100.0 dur: dur loudness: 0.5) play.
