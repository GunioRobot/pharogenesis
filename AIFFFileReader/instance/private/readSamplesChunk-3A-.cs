readSamplesChunk: chunkSize
	"Read a SSND chunk. All AIFF files with a non-zero frameCount contain exactly one chunk of this type."

	| offset blockSize bytesOfSamples s |
	offset _ in nextNumber: 4.
	blockSize _ in nextNumber: 4.
	((offset ~= 0) or: [blockSize ~= 0])
		ifTrue: [^ self error: 'this AIFF reader cannot handle blocked sample chunks'].
	bytesOfSamples _ chunkSize - 8.
	bytesOfSamples = (channelCount * frameCount * (bitsPerSample // 8))
		ifFalse: [self error: 'actual sample count does not match COMM chunk'].

	channelDataOffset _ in position.  "record stream position for start of data"
	skipDataChunk ifTrue: [in skip: (chunkSize - 8). ^ self].  "if skipDataChunk, skip sample data"

	(mergeIfStereo and: [channelCount = 2])
		ifTrue: [
			channelData _ Array with: (SoundBuffer newMonoSampleCount: frameCount)]
		ifFalse: [
			channelData _
				(1 to: channelCount) collect: [:i | SoundBuffer newMonoSampleCount: frameCount]].

	(bytesOfSamples < (Smalltalk garbageCollectMost - 300000))
		ifTrue: [s _ ReadStream on: (in next: bytesOfSamples)]  "bulk-read, then process"
		ifFalse: [s _ in].  "not enough space to buffer; read directly from file"

	"mono and stereo are special-cased for better performance"
	channelCount = 1 ifTrue: [^ self readMonoChannelDataFrom: s].
	channelCount = 2 ifTrue: [
		mergeIfStereo
			ifTrue: [channelCount _ 1. ^ self readMergedStereoChannelDataFrom: s]
			ifFalse: [^ self readStereoChannelDataFrom: s]].
	self readMultiChannelDataFrom: s.
