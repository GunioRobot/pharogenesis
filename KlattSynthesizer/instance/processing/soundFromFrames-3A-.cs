soundFromFrames: aCollection
	^ SampledSound samples: (self samplesFromFrames: aCollection) samplingRate: samplingRate