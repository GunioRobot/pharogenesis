fullBounds
	super fullBounds.
	owner class == TilePadMorph ifTrue: [owner bounds: bounds].
	^ fullBounds