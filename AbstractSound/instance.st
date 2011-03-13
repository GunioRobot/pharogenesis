Object
	subclass: #AbstractSound
	instanceVariableNames: 'envelopes mSecsSinceStart samplesUntilNextControl scaledVol scaledVolIncr scaledVolLimit'
	classVariableNames:
		'FloatScaleFactor MaxScaledValue PitchesForBottomOctave ScaleFactor Sounds TopOfBottomOctave UnloadedSnd'
	poolDictionaries: ''
	category: 'Sound-Synthesis'