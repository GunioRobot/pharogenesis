sound: aSound
	| buffer |
	buffer _ aSound samples mergeStereo.
	graph data: buffer.
	loopLength := loopEnd := buffer size.
	self samplingRate: aSound originalSamplingRate.
	loopCycles :=  buffer size / aSound originalSamplingRate * 400.
	perceivedFrequency := 400.
