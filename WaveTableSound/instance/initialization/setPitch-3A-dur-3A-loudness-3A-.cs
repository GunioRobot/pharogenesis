setPitch: p dur: d loudness: l
	"((WaveTableSound pitch: 880.0 dur: 1.5 loudness: 500) decayRate: 0.94) play"

	waveTable _ SineTable.
	waveTableSize _ waveTable size.
	self pitch: p.
	initialCount _ (d * self samplingRate asFloat) rounded.
	initialAmplitude _ l rounded.
	decayRate _ 1.0.  "no decay"
	self reset.