loadBuffer: aSoundBuffer compressedSampleCount: sampleCount
	"Load the given sound buffer from the compressed sample stream."
	"Details: Most codecs decode in multi-sample units called 'frames'. Since the requested sampleCount is typically not an even multiple of the frame size, we need to deal with partial frames. The unused samples from a partial frame are retained until the next call to this method."

	| n samplesNeeded frameCount encodedBytes r decodedCount buf j |
	"first, use any leftover samples"
	n _ self loadFromLeftovers: aSoundBuffer sampleCount: sampleCount.
	samplesNeeded _ sampleCount - n.
	samplesNeeded <= 0 ifTrue: [^ self].

	"decode an integral number of full compression frames"
	frameCount _ samplesNeeded // codec samplesPerFrame.
	encodedBytes _ stream next: (frameCount * codec bytesPerEncodedFrame).
	r _ codec decodeFrames: frameCount from: encodedBytes at: 1 into: aSoundBuffer at: n + 1.
	decodedCount _ r last.
	decodedCount >= samplesNeeded ifTrue: [^ self].

	"decode one last compression frame to finish filling the buffer"
	buf _ SoundBuffer newMonoSampleCount: codec samplesPerFrame.
	encodedBytes _ stream next: codec bytesPerEncodedFrame.
	codec decodeFrames: 1 from: encodedBytes at: 1 into: buf at: 1.
	j _ 0.
	(n + decodedCount + 1) to: sampleCount do: [:i |
		aSoundBuffer at: i put: (buf at: (j _ j + 1))].

	"save the leftover samples"
	leftoverSamples _ buf copyFrom: (j + 1) to: buf monoSampleCount.
