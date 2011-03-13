setPitch: p dur: d loudness: l

	super setPitch: p dur: d loudness: l.
	self modulation: 900 multiplier: 0.76.
	self modulationDecay: 0.92.
	self decayRate: 0.85.

