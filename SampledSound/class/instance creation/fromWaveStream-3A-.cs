fromWaveStream: fileStream

	| stream header data type channels samplingRate blockAlign bitsPerSample leftAndRight |
	header _ self readWaveChunk: 'fmt ' inRIFF: fileStream.
	data _ self readWaveChunk: 'data' inRIFF: fileStream.
	fileStream close.
	stream _ ReadStream on: header.
	type _ self next16BitWord: false from: stream.
	type = 1 ifFalse: [^ self error:'Unexpected wave format'].
	channels _ self next16BitWord: false from: stream.
	(channels < 1 or: [channels > 2])
		ifTrue: [^ self error: 'Unexpected number of wave channels'].
	samplingRate _ self next32BitWord: false from: stream.
	stream skip: 4. "skip average bytes per second"
	blockAlign _ self next16BitWord: false from: stream.
	bitsPerSample _ self next16BitWord: false from: stream.
	(bitsPerSample = 8 or: [bitsPerSample = 16])
		ifFalse: [  "recompute bits per sample"
			bitsPerSample _ (blockAlign // channels) * 8].

	bitsPerSample = 8
		ifTrue: [data _ self convert8bitUnsignedTo16Bit: data]
		ifFalse: [data _ self convertBytesTo16BitSamples: data mostSignificantByteFirst: false].

	channels = 2 ifTrue: [
		leftAndRight _ data splitStereo.
		^ MixedSound new
			add: (self samples: leftAndRight first samplingRate: samplingRate) pan: 0.0;
			add: (self samples: leftAndRight last samplingRate: samplingRate) pan: 1.0;
			yourself].

	^ self samples: data samplingRate: samplingRate
