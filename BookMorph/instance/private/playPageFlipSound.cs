playPageFlipSound
	(self world soundsEnabled "user-controllable" and:
		[PageFlipSoundOn])  "jhm's mechanism to supress sounds at init time"
			ifTrue: [SampledSound playSoundNamed: 'camera'].
