recordSoundStreamBlock: data

	| newBufs |
	streamingSound frameNumber + 1 = frame 
		ifFalse: [self flushStreamingSound].
	newBufs := ADPCMCodec new
		decodeFlash: data
		sampleCount: streamingSound sampleCount
		stereo: streamingSound stereo.
	streamingSound buffers with: newBufs do:
		[:streamBuf :newBuf | streamBuf nextPutAll: newBuf].
	streamingSound frameNumber: frame.
