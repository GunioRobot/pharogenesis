perceivedFrequency: aNumber

	perceivedFrequency _ aNumber.
	(loopCycles > 0) ifTrue: [
		loopLength _ samplingRate asFloat * loopCycles / perceivedFrequency].
