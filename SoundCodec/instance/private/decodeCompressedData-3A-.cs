decodeCompressedData: aByteArray
	"Decode the entirety of the given encoded data buffer with this codec. Answer a monophonic SoundBuffer containing the uncompressed samples."

	| frameCount result increments |
	frameCount _ self frameCount: aByteArray.
	result _ SoundBuffer newMonoSampleCount: frameCount * self samplesPerFrame.
	self reset.
	increments _ self decodeFrames: frameCount from: aByteArray at: 1 into: result at: 1.
	((increments first = aByteArray size) and: [increments last = result size]) ifFalse: [
		self error: 'implementation problem; increment sizes should match buffer sizes'].
	^ result
