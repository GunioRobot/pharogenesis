decompressSound: aByteArray stereo: stereo samples: numSamples rate: samplingRate

	| buffers |
	buffers _ ADPCMCodec new
		decodeFlash: aByteArray sampleCount: numSamples stereo: stereo.
	^ self createSoundFrom: buffers stereo: stereo samplingRate: samplingRate
