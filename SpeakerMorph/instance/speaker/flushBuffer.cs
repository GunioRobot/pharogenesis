flushBuffer

	| buf |
	buf _ buffer contents.
	buffer resetContents.
	sound isPlaying ifFalse: [sound _ SequentialSound new].
	sound add: (SampledSound samples: buf samplingRate: 11025).
	sound isPlaying
		ifTrue: [sound pruneFinishedSounds]
		ifFalse: [sound play].
