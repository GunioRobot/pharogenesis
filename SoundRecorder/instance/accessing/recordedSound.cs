recordedSound
	"Return the sound that was recorded."

	| snd |
	stereo ifTrue: [^ self condensedStereoSound].
	snd _ SequentialSound new.
	recordedBuffers do: [:buf |
		snd add: (SampledSound new setSamples: buf samplingRate: samplingRate)].
	^ snd
