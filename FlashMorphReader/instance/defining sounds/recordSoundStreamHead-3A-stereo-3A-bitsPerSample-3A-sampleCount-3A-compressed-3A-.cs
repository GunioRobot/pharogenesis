recordSoundStreamHead: mixFmt stereo: stereo bitsPerSample: bitsPerSample sampleCount: sampleCount compressed: compressed
	streamingSound buffers isNil ifFalse:[self flushStreamingSound].
	streamingSound mixFmt: mixFmt.
	streamingSound stereo: stereo.
	streamingSound bitsPerSample: bitsPerSample.
	streamingSound sampleCount: sampleCount.
	streamingSound compressed: compressed.
	streamingSound samplingRate: (frameRate * sampleCount) truncated.
	streamingSound buffers: (self createSoundBuffersOfSize: sampleCount stereo: stereo).
	streamingSound firstFrame: frame.
	streamingSound frameNumber: frame.
