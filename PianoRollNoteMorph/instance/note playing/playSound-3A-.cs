playSound: aSoundOrNil

	SoundPlaying ifNotNil: [SoundPlaying stopGracefully].
	SoundPlaying := aSoundOrNil.
	SoundPlaying ifNotNil: [SoundPlaying play].