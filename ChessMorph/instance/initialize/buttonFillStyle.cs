buttonFillStyle

	| fill |
	fill _ GradientFillStyle ramp: {
		0.0 -> (Color r: 0.05 g: 0.5 b: 1.0). 
		1.0 -> (Color r: 0.85 g: 0.95 b: 1.0)}.
	fill origin: (0@0).
	fill direction: 40@10.
	fill radial: false.
	^ fill
