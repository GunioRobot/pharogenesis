encodeSoundBuffer: aSoundBuffer
	"Encode the entirety of the given monophonic SoundBuffer with this codec. Answer a ByteArray containing the compressed sound data."

	| codeFrameSize frameSize fullFrameCount lastFrameSamples result increments finalFrame i lastIncs |
	frameSize _ self samplesPerFrame.
	fullFrameCount _ aSoundBuffer monoSampleCount // frameSize.
	lastFrameSamples _ aSoundBuffer monoSampleCount - (fullFrameCount * frameSize).
	codeFrameSize _ self bytesPerEncodedFrame.
	codeFrameSize = 0 ifTrue:
		["Allow room for 1 byte per sample for variable-length compression"
		codeFrameSize _ frameSize].
	lastFrameSamples > 0
		ifTrue: [result _ ByteArray new: (fullFrameCount + 1) * codeFrameSize]
		ifFalse: [result _ ByteArray new: fullFrameCount * codeFrameSize].
	self reset.
	increments _ self encodeFrames: fullFrameCount from: aSoundBuffer at: 1 into: result at: 1.
	lastFrameSamples > 0 ifTrue: [
		finalFrame _ SoundBuffer newMonoSampleCount: frameSize.
		i _ fullFrameCount * frameSize.
		1 to: lastFrameSamples do: [:j |
			finalFrame at: j put: (aSoundBuffer at: (i _ i + 1))].
		lastIncs _ self encodeFrames: 1 from: finalFrame at: 1 into: result at: 1 + increments second.
		increments _ Array with: increments first + lastIncs first
							with: increments second + lastIncs second].
	increments second < result size
		ifTrue: [^ result copyFrom: 1 to: increments second]
		ifFalse: [^ result]
