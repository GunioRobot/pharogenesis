beep: soundName
	"Make the given sound, unless the making of sound is disabled in Preferences."

	self deprecated: 'Use SampledSound>>playSoundNamed: instead.'.
	Preferences soundsEnabled
		ifTrue: [self playSoundNamed: soundName]
