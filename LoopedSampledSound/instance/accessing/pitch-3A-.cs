pitch: p

	scaledIndexIncr _
		((p asFloat * originalSamplingRate * FloatLoopIndexScaleFactor) /
		 (perceivedPitch * self samplingRate asFloat)) asInteger.

	sampleCountForRelease > 0
		ifTrue: [releaseCount _ (sampleCountForRelease * LoopIndexScaleFactor) // scaledIndexIncr]
		ifFalse: [releaseCount _ 0].
