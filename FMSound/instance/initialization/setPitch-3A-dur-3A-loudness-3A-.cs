setPitch: p dur: d loudness: vol
	"(FMSound pitch: 440.0 dur: 2.5 loudness: 0.4) play"

	super setPitch: p dur: d loudness: vol.
	waveTable _ SineTable.
	scaledWaveTableSize _ waveTable size * ScaleFactor.
	modulation ifNil: [modulation _ 0.0].
	multiplier ifNil: [multiplier _ 0.0].
	self pitch: p.
	self reset.
