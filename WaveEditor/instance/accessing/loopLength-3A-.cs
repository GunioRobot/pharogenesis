loopLength: aNumber

	loopLength _ aNumber.
	((loopCycles > 0) and: [loopLength > 0]) ifTrue: [
		perceivedFrequency _ samplingRate asFloat * loopCycles / loopLength].

