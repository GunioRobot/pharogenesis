beep
	"There is sound support, so we use the default
	sampled sound for a beep."

	Preferences soundsEnabled ifTrue: [
		SampledSound beep]