playSound: aSoundOrNil

	SoundPlaying ifNotNil: [SoundPlaying stopGracefully].
	SoundPlaying _ aSoundOrNil.
	SoundPlaying ifNotNil: [SoundPlaying play].