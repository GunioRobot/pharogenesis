decodeFlash: aByteArray sampleCount: sampleCount stereo: stereoFlag

	| bits |
	encodedBytes _ aByteArray.
	byteIndex _ 0.
	bitPosition _ 0.
	currentByte _ 0.
	bits _ 2 + (self nextBits: 2).  "bits per sample"
	self initializeForBitsPerSample: bits samplesPerFrame: 4096.
	stereoFlag
		ifTrue: [
			self resetForStereo.
			samples _ SoundBuffer newMonoSampleCount: sampleCount.
			rightSamples _ SoundBuffer newMonoSampleCount: sampleCount.
			sampleIndex _ 0.
			self privateDecodeStereo: sampleCount.
			^ Array with: samples with: rightSamples]
		ifFalse: [
			samples _ SoundBuffer newMonoSampleCount: sampleCount.
			sampleIndex _ 0.
			self privateDecodeMono: sampleCount.
			^ Array with: samples].
