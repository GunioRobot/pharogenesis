openEyelid
	self extent: self extent x @ (self extent x * 37.0 / 30.0) rounded.
	self position: self position - (0 @ (self extent y // 2)).
	self addMorphFront: self iris