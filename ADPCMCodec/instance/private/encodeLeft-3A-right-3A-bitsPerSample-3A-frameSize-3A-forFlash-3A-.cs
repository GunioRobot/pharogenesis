encodeLeft: leftSoundBuffer right: rightSoundBuffer bitsPerSample: bits frameSize: frameSize forFlash: flashFlag

	| stereoFlag sampleCount sampleBitCount bitCount |
	self initializeForBitsPerSample: bits samplesPerFrame: frameSize.
	stereoFlag _ rightSoundBuffer notNil.
	sampleCount _ leftSoundBuffer monoSampleCount.
	stereoFlag
		ifTrue: [sampleBitCount _ 2 * (sampleCount * bitsPerSample)]
		ifFalse: [sampleBitCount _ sampleCount * bitsPerSample].
	bitCount _ sampleBitCount +
		(self headerBitsForSampleCount: sampleCount stereoFlag: stereoFlag).

	encodedBytes _ ByteArray new: ((bitCount / 8) ceiling roundUpTo: self bytesPerEncodedFrame).
	byteIndex _ 0.
	bitPosition _ 0.
	currentByte _ 0.
	flashFlag ifTrue: [self nextBits: 2 put: bits - 2].
	stereoFlag
		ifTrue: [
			samples _ Array with: leftSoundBuffer with: rightSoundBuffer.
			sampleIndex _ Array with: 0 with: 0.
			self privateEncodeStereo: sampleCount]
		ifFalse: [
			samples _ leftSoundBuffer.
			sampleIndex _ 0.
			self privateEncodeMono: sampleCount].

	^ encodedBytes
