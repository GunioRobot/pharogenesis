downSampleLowPassFiltering: doFiltering
	"Cut my sampling rate in half. Use low-pass filtering (slower) if doFiltering is true."
	"Note: This operation loses information, and modifies the receiver in place."

	| stereo newLoopLength |
	stereo _ self isStereo.
	leftSamples _ leftSamples downSampledLowPassFiltering: doFiltering.
	stereo
		ifTrue: [rightSamples _ rightSamples downSampledLowPassFiltering: doFiltering]
		ifFalse: [rightSamples _ leftSamples].
	originalSamplingRate _ originalSamplingRate / 2.0.
	loopEnd odd
		ifTrue: [newLoopLength _ (self loopLength / 2.0) + 0.5]
		ifFalse: [newLoopLength _ self loopLength / 2.0].
	firstSample _ (firstSample + 1) // 2.
	lastSample _ (lastSample + 1) // 2.
	loopEnd _ (loopEnd + 1) // 2.
	scaledLoopLength _ (newLoopLength * LoopIndexScaleFactor) asInteger.
	scaledIndexIncr _ scaledIndexIncr // 2.
