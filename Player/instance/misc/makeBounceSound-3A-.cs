makeBounceSound: soundName

	Preferences soundsEnabled
		ifTrue: [self playSoundNamed: soundName].
