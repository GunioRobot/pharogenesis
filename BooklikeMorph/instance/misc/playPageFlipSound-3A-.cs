playPageFlipSound: soundName
	self presenter ifNil: [^ self].  "Avoid failures when called too early"
	(Preferences soundsEnabled "user-controllable" and:
		[PageFlipSoundOn])  "mechanism to suppress sounds at init time"
			ifTrue: [self playSoundNamed: soundName].
