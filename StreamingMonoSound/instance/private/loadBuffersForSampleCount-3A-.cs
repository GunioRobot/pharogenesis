loadBuffersForSampleCount: count
	"Load the sound buffers from the stream."

	| snd buf sampleCount |
	snd _ mixer sounds first.
	buf _ snd samples.
	buf monoSampleCount = count ifFalse: [
		buf _ SoundBuffer newMonoSampleCount: count.
		snd setSamples: buf samplingRate: streamSamplingRate].
	sampleCount _ count min: (totalSamples - self currentSampleIndex).
	sampleCount < count ifTrue: [buf primFill: 0].

	codec
		ifNil: [self loadBuffer: buf uncompressedSampleCount: sampleCount]
		ifNotNil: [self loadBuffer: buf compressedSampleCount: sampleCount].

	mixer reset.
