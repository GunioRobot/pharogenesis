SoundCodec
	subclass: #ADPCMCodec
	instanceVariableNames:
		'predicted index deltaSignMask deltaValueMask deltaValueHighBit frameSizeMask currentByte bitPosition byteIndex encodedBytes samples rightSamples sampleIndex bitsPerSample stepSizeTable indexTable'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Sound-Synthesis'