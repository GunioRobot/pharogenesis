beep: soundName
	Preferences soundsEnabled
		ifTrue: [self playSoundNamed: soundName]
