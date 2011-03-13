pitch: p

	increment _ (p asFloat * waveTableSize asFloat) // self samplingRate asFloat.
	increment _ (increment max: 1) min: ((waveTableSize // 2) - 1).
