modulation: mod ratio: freqRatio
	"Set the modulation index and carrier to modulation frequency ratio for this sound, and compute the internal state that depends on these parameters."

	modulation _ mod asFloat.
	multiplier _ freqRatio asFloat.
	self internalizeModulationAndRatio.
