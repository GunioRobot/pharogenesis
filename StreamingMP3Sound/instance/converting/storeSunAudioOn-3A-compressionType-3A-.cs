storeSunAudioOn: aBinaryStream compressionType: compressionName
	"Store myself on the given stream as a monophonic sound compressed with the given type of compression. The sampling rate is reduced to 22050 samples/second if it is higher."

	| fmt inBufSize samplesPerFrame codec inBuf compressed outSamplingRate audioWriter samplesRemaining outBuf counts byteCount |
	self pause; reset.  "stop playing and return to beginning"

	fmt _ SunAudioFileWriter formatCodeForCompressionType: compressionName.
	inBufSize _ 64000.
	samplesPerFrame _ 1.
	codec _ SunAudioFileWriter codecForFormatCode: fmt.
	codec ifNotNil: [
		samplesPerFrame _ codec samplesPerFrame.
		inBufSize _ inBufSize roundUpTo: (2 * samplesPerFrame).
		compressed _ ByteArray new:
			(inBufSize // samplesPerFrame) * codec bytesPerEncodedFrame].
	inBuf _ SoundBuffer newMonoSampleCount: inBufSize.
	outSamplingRate _ streamSamplingRate.
	streamSamplingRate > 22050 ifTrue: [
		streamSamplingRate = 44100 ifFalse: [self error: 'unexpected MP3 sampling rate'].
		outSamplingRate _ 22050].

	"write audio header"
	audioWriter _ SunAudioFileWriter onStream: aBinaryStream.
	audioWriter writeHeaderSamplingRate: outSamplingRate format: fmt.

	"convert and write sound data"
	'Storing audio...' displayProgressAt: Sensor cursorPoint
		from: 0 to: totalSamples during: [:bar |
			samplesRemaining _ totalSamples.
			[samplesRemaining > 0] whileTrue: [
				bar value: totalSamples - samplesRemaining.
				samplesRemaining < inBuf monoSampleCount ifTrue: [
					inBuf _ SoundBuffer newMonoSampleCount:
						(samplesRemaining roundUpTo: 2 * samplesPerFrame)].
				mpegFile audioReadBuffer: inBuf stream: 0 channel: 0.
				outSamplingRate < streamSamplingRate
					ifTrue: [outBuf _ inBuf downSampledLowPassFiltering: true]
					ifFalse: [outBuf _ inBuf].
				codec
					ifNil: [audioWriter appendSamples: outBuf]
					ifNotNil: [
						counts _ codec
							encodeFrames: (outBuf size // samplesPerFrame)
							from: outBuf at: 1
							into: compressed at: 1.
						byteCount _ counts last.
						byteCount = compressed size
							ifTrue: [audioWriter appendBytes: compressed]
							ifFalse: [audioWriter appendBytes: (compressed copyFrom: 1 to: byteCount)]].
				samplesRemaining _ samplesRemaining - inBuf monoSampleCount]].

	"update audio header"
	audioWriter updateHeaderDataSize.
