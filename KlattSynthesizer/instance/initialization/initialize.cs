initialize
	"Initialize the Klatt synthesizer."

	"Seed for noise generation:"
	seed := 17.
	"Sampling rate and millseconds per frame:"
	self samplingRate: 22025.
	self millisecondsPerFrame: self defaultMillisecondsPerFrame.
	"Number of formants in the cascade branch: (0 to 8)"
	self cascade: 0