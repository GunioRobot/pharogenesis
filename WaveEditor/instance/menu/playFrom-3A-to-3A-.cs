playFrom: start to: end

	| sz i1 i2 snd |
	sz _ graph data size.
	i1 _ ((start + 1) min: sz) max: 1.
	i2 _ ((end + 1) min: sz) max: i1.
	(i1 + 2) >= i2 ifTrue: [^ self].
	snd _ SampledSound
		samples: (graph data copyFrom: i1 to: i2)
		samplingRate: samplingRate.
	snd play.
