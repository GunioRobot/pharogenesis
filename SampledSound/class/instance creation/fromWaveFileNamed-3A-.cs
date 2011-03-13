fromWaveFileNamed: fileName
	"(SampledSound fromWaveFileNamed: 'c:\windows\media\chimes.wav') play"
	"| snd fd |
	fd := FileDirectory on:'c:\windows\media\'.
	fd fileNames do: [:n |
		(n asLowercase endsWith: '.wav')
			ifTrue: [
				snd _ SampledSound fromWaveFileNamed: (fd pathName,n).
				snd play.
				SoundPlayer waitUntilDonePlaying: snd]]."

	| stream header data type channels samplingRate blockAlign bitsPerSample leftData rightData index dataWord |
	stream _ FileStream oldFileNamed: fileName.
	header _ self readWaveChunk: 'fmt ' inRIFF: stream.
	data _ self readWaveChunk: 'data' inRIFF: stream.
	stream close.
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
		leftData _ SoundBuffer newMonoSampleCount: data size.
		rightData _ SoundBuffer newMonoSampleCount: data size.
		stream _ ReadStream on: data.
		index _ 1.
		[stream atEnd] whileFalse: [
			dataWord _ self next16BitWord: false from: stream.
			dataWord > 16r8000 ifTrue: [dataWord _ dataWord - 16r10000].
			leftData at: index put: dataWord.
			dataWord _ self next16BitWord: false from: stream.
			dataWord > 16r8000 ifTrue: [dataWord _ dataWord - 16r10000].
			rightData at: index put: dataWord.
			index _ index + 1].
		^ MixedSound new
			add: (self samples: leftData samplingRate: samplingRate) pan: 0.0;
			add: (self samples: rightData samplingRate: samplingRate) pan: 1.0;
			yourself].

	^ self samples: data samplingRate: samplingRate
