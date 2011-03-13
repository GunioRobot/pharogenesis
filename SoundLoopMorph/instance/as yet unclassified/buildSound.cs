buildSound
	"Build a compound sound for the next iteration of the loop."

	| mixer soundMorphs startTime pan |
	mixer _ MixedSound new.
	mixer add: (RestSound dur: (self width - (2 * borderWidth)) / 128.0).
	soundMorphs _ self submorphs select: [:m | m respondsTo: #sound].
	soundMorphs do: [:m |
		startTime _ (m position x - (self left + borderWidth)) / 128.0.
		pan _ (m position y - (self top + borderWidth)) asFloat / (self height - (2 * borderWidth) - m height).
		mixer add: ((RestSound dur: startTime), m sound copy) pan: pan].
	^ mixer
