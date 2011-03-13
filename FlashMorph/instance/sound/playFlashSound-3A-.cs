playFlashSound: aSound
	"Play the given sound at the volume level for Flash sounds."

	FlashSoundVolume ifNil: [FlashSoundVolume := 0.3].
	(MixedSound new add: aSound pan: 0.5 volume: FlashSoundVolume) play.
