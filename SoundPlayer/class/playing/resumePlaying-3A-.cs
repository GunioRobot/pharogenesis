resumePlaying: aSound
	"Start playing the given sound without resetting it; it will resume playing from where it last stopped."

	| quickStart |
	Preferences disableSounds ifTrue: [^ self].
	quickStart _ true.
	PlayerProcess == nil ifTrue: [
		self canStartPlayer ifFalse: [^ self].
		self startUp. quickStart _ false].

	PlayerSemaphore critical: [
		(ActiveSounds includes: aSound)
			ifTrue: [quickStart _ false]
			ifFalse: [
				quickStart ifFalse: [ActiveSounds add: aSound]]].

	"quick-start the given sound, unless the sound player has just started"
	quickStart ifTrue: [self startPlayingImmediately: aSound].
