loopStart: index

	| start len |
	start _ self fractionalLoopStartAt: index.
	len _ (loopEnd asFloat - start) + 1.0.
	loopCycles _ (len / (samplingRate / perceivedFrequency)) rounded.
	self loopLength: len.
