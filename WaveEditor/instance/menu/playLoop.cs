playLoop

	| sz i1 i2 snd len |
	sz _ graph data size.
	i1 _ ((loopEnd - loopLength) truncated min: sz) max: 1.
	i2 _ (loopEnd min: sz) max: i1.
	len _ (i2 - i1) + 1.
	len < 2 ifTrue: [^ self].

	snd _ LoopedSampledSound new
		samples: (graph data copyFrom: i1 to: i2)
		loopEnd: len
		loopLength: loopLength
		pitch: 100.0
		samplingRate: samplingRate.

	"sustain for the longer of four loops or two seconds"
	snd setPitch: 100.0
		dur: (((4.0 * loopLength) / samplingRate) max: 2.0)
		loudness: 0.5.
	snd play.
