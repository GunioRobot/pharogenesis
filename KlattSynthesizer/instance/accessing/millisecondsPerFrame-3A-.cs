millisecondsPerFrame: aNumber
	self samplesPerFrame: (aNumber * self samplingRate / 1000) asInteger