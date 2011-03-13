beep: soundName
	"Make the given sound, unless the making of sound is disabled in Preferences"

	Preferences soundsEnabled
		ifTrue: [self playSoundNamed: soundName]
