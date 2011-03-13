doControl

	decayRate ~= 1.0 ifTrue: [
		amplitude _ (decayRate * amplitude asFloat) asInteger.
	].
