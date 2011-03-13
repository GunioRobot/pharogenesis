AbstractSound
	subclass: #LoopedSampledSound
	instanceVariableNames:
		'initialCount count releaseCount sampleCountForRelease leftSamples rightSamples originalSamplingRate perceivedPitch gain firstSample lastSample loopEnd scaledLoopLength scaledIndex scaledIndexIncr '
	classVariableNames: 'FloatLoopIndexScaleFactor LoopIndexFractionMask LoopIndexScaleFactor '
	poolDictionaries: ''
	category: 'Sound-Synthesis'