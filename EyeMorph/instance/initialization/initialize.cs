initialize
	super initialize.
	self color: (Color r: 1.0 g: 0.968 b: 0.935).
	self borderColor: Color black; borderWidth: 1.
	self extent: 30 @ 37.
	self addMorphFront: (iris _ EllipseMorph new extent: 6 @ 6; borderWidth: 0; color: Color black).
	self lookAtFront