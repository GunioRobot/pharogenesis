pitch

	^ (self samplingRate * (scaledIndexIncr // ScaleFactor)) asFloat / waveTable size
