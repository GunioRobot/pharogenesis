flash
	| c w |
	c _ self color.
	self color: Color black.
	(w _ self world) ifNotNil: [w displayWorldSafely].
	self color: c
