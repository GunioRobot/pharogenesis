reverbState: aBoolean

	aBoolean
		ifTrue: [SoundPlayer startReverb]
		ifFalse: [SoundPlayer stopReverb].
