compressAndDecompress: aSound
	"Compress and decompress the given sound. Overridden to use same bits per sample for both compressing and decompressing."

	| compressed decoder |
	compressed _ self compressSound: aSound.
	decoder _ self class new
		initializeForBitsPerSample: bitsPerSample
		samplesPerFrame: 0.
	^ decoder decompressSound: compressed

