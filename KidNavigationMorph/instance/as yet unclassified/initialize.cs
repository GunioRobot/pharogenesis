initialize

	| fill |
	super initialize.
	self layoutInset: 12.
	fill _ GradientFillStyle ramp: {
		0.0->(Color r: 0.032 g: 0.0 b: 0.484).
		1.0->(Color r: 0.194 g: 0.032 b: 1.0)
	}.
	fill origin: self bounds topLeft.
	fill direction: 0@200.
	fill radial: false.
	self fillStyle: fill.
	self removeAllMorphs.
	self addButtons.

