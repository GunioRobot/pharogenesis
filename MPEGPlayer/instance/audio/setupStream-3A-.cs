setupStream: aStream
	self sampleRate: (self audioSampleRate: aStream).
	SoundPlayer startPlayerProcessBufferSize:  8192 "(SoundPlayer bufferMSecs * self sampleRate) // 1000"
		rate: self sampleRate stereo: true.
