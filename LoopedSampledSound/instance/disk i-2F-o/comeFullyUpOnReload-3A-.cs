comeFullyUpOnReload: smartRefStream
	"Convert my sample buffers from ByteArrays into SampleBuffers after raw loading from a DataStream. Answer myself."

	leftSamples == rightSamples
		ifTrue: [
			leftSamples _ SoundBuffer fromByteArray: self leftSamples.
			rightSamples _ leftSamples]
		ifFalse: [
			leftSamples _ SoundBuffer fromByteArray: self leftSamples.
			rightSamples _ SoundBuffer fromByteArray: self rightSamples].

