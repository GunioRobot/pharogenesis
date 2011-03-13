AbstractSound
	subclass: #FMSound
	instanceVariableNames:
		'initialCount count waveTable scaledWaveTableSize scaledIndex scaledIndexIncr modulation multiplier normalizedModulation scaledOffsetIndex scaledOffsetIndexIncr'
	classVariableNames: 'SineTable'
	poolDictionaries: ''
	category: 'Sound-Synthesis'