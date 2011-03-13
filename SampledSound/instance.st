AbstractSound
	subclass: #SampledSound
	instanceVariableNames:
		'initialCount count samples originalSamplingRate samplesSize scaledIndex indexHighBits scaledIncrement'
	classVariableNames:
		'CoffeeCupClink DefaultSampleTable IncrementFractionBits IncrementScaleFactor NominalSamplePitch ScaledIndexOverflow SoundLibrary'
	poolDictionaries: ''
	category: 'Sound-Synthesis'