createSoundBuffersOfSize: numSamples stereo: stereo
	| channels buffers |
	channels := stereo ifTrue:[2] ifFalse:[1].
	buffers := Array new: channels.
	1 to: channels do:[:i| 
		buffers at: i put: 
			(WriteStream on: ((SoundBuffer newMonoSampleCount: numSamples)))].
	^buffers