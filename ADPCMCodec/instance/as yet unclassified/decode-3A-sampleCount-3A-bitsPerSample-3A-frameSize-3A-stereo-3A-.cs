decode: aByteArray sampleCount: count bitsPerSample: bits frameSize: frameSize stereo: stereoFlag

	self initializeForBitsPerSample: bits samplesPerFrame: frameSize.
	encodedBytes _ aByteArray.
	byteIndex _ 0.
	bitPosition _ 0.
	currentByte _ 0.
	stereoFlag
		ifTrue: [
			self resetForStereo.
			samples _ SoundBuffer newMonoSampleCount: count.
			rightSamples _ SoundBuffer newMonoSampleCount: count.
			sampleIndex _ 0.
			self privateDecodeStereo: count.
			^ Array with: samples with: rightSamples]
		ifFalse: [
			samples _ SoundBuffer newMonoSampleCount: count.
			sampleIndex _ 0.
			self privateDecodeMono: count.
			^ samples]
