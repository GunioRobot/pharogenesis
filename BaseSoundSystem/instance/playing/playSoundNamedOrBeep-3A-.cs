playSoundNamedOrBeep: soundName
	"There is sound support, so we play the given sound
	instead of beeping."

	Preferences soundsEnabled ifTrue: [
		^self playSoundNamed: soundName]