storeAIFFOnFileNamed: fileName

	| f |
	f _ (FileStream fileNamed: fileName) binary.
	self storeAIFFSamples: self samples samplingRate: self originalSamplingRate on: f.
	f close.
