doControl

	super doControl.
	modulationDecay ~= 1.0 ifTrue: [
		modulation _ (modulationDecay * modulation asFloat) asInteger.
	].
