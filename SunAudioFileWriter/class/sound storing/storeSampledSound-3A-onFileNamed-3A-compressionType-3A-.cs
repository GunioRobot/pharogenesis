storeSampledSound: aSampledSound onFileNamed: fileName compressionType: aString
	"Store the samples of the given sampled sound on a file with the given name using the given type of compression. See formatCodeForCompressionType: for the list of compression types."

	| fmt codec f compressed |
	fmt _ self formatCodeForCompressionType: aString.
	codec _ self codecForFormatCode: fmt.
	f _ self onFileNamed: fileName.
	f writeHeaderSamplingRate: aSampledSound originalSamplingRate format: fmt.
	codec
		ifNil: [f appendSamples: aSampledSound samples]
		ifNotNil: [
			compressed _ codec encodeSoundBuffer: aSampledSound samples.
			f appendBytes: compressed].
	f closeFile.
