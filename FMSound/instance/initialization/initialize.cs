initialize

	super initialize.
	waveTable _ SineTable.
	scaledWaveTableSize _ waveTable size * ScaleFactor.
	self setPitch: 440.0 dur: 1.0 loudness: 0.2.
