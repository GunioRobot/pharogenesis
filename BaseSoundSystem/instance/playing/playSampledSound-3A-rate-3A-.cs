playSampledSound: samples rate: rate

	Preferences soundsEnabled ifTrue: [
		(SampledSound samples: samples samplingRate: rate) play]