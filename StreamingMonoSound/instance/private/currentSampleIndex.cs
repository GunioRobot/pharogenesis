currentSampleIndex
	"Answer the index of the current sample."

	| bytePosition frameIndex |
	bytePosition _ stream position - audioDataStart.
	codec
		ifNil: [^ bytePosition // 2]
		ifNotNil: [
			frameIndex _ bytePosition // codec bytesPerEncodedFrame.
			^ (frameIndex * codec samplesPerFrame) - leftoverSamples monoSampleCount].
