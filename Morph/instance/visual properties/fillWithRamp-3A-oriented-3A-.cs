fillWithRamp: rampSpecs oriented: aRatio

	| fill |
	fill _ GradientFillStyle ramp: rampSpecs.
	fill origin: self bounds topLeft.
	fill direction: (self bounds extent * aRatio) truncated.
	fill radial: false.
	self fillStyle: fill.
