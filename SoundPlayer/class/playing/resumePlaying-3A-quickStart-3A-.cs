resumePlaying: aSound quickStart: quickStart
	"Start playing the given sound without resetting it; it will resume playing from where it last stopped. If quickStart is true, then try to start playing the given sound immediately."

	| doQuickStart |
	Preferences soundsEnabled ifFalse: [^ self].
	doQuickStart _ quickStart.
	Preferences soundQuickStart ifFalse: [doQuickStart _ false].
	PlayerProcess == nil ifTrue: [
		self canStartPlayer ifFalse: [^ self].
		self startUp.
		"Check if startup was successful"
		SoundSupported ifFalse:[^self].
		doQuickStart _ false].

	PlayerSemaphore critical: [
		(ActiveSounds includes: aSound)
			ifTrue: [doQuickStart _ false]
			ifFalse: [
				doQuickStart ifFalse: [ActiveSounds add: aSound]]].

	"quick-start the given sound, unless the sound player has just started"
	doQuickStart ifTrue: [self startPlayingImmediately: aSound].
