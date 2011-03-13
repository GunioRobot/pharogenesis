resumeSound: aSound
	"Start playing the given sound without resetting it; it will resume playing from where it last stopped."

	PlayerProcess == nil ifTrue: [
		(self confirm: 'Start the sound player process?') ifFalse: [ ^ self ].
		self startUp.
	].

	PlayerSemaphore critical: [
		(ActiveSounds includes: aSound) ifFalse: [
			ActiveSounds add: aSound.
		].
	].