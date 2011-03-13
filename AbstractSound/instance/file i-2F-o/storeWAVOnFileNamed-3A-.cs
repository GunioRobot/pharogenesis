storeWAVOnFileNamed: fileName

	| f |
	f _ (FileStream fileNamed: fileName) binary.
	self storeWAVSamplesSamplingRate: self samplingRate on: f.
	f close.