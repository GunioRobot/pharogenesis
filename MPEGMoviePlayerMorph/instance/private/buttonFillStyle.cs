buttonFillStyle

	| fill |
	fill _ GradientFillStyle ramp: {
		0.0->(Color r: 0.742 g: 0.903 b: 1.0).
		1.0->(Color r: 0.516 g: 0.71 b: 1.0)
	}.
	fill origin: self bounds topLeft + (14@3).
	fill direction: 8@6.
	fill radial: false.
	^ fill
