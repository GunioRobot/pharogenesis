playSoundNamed: soundName
	"There is sound support, so we play the given sound."

	Preferences soundsEnabled ifTrue: [
		SampledSound playSoundNamed: soundName asString]