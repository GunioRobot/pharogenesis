makeLoopedSampledSound

	| data end snd basePitch |
	data _ graph data.
	((loopEnd = 0) or: [loopLength = 0])
		ifTrue: [  "save as unlooped"
			perceivedFrequency = 0
				ifTrue: [basePitch _ 100.0]
				ifFalse: [basePitch _ perceivedFrequency].
			snd _ LoopedSampledSound new
				unloopedSamples: data pitch: basePitch samplingRate: samplingRate]
		ifFalse: [
			end _ (loopEnd min: data size) max: 1.
			basePitch _ (samplingRate * loopCycles) / loopLength.
			snd _ LoopedSampledSound new
				samples: data loopEnd: end loopLength: loopLength
				pitch: basePitch samplingRate: samplingRate].
	snd addReleaseEnvelope.
	^ snd
