playPageFlipSound

	(self world soundsEnabled "user-controllable" and:
		[PageFlipSoundOn])  "mechanism to suppress sounds at init time"
			ifTrue: [self playSoundNamed: 'camera'].
