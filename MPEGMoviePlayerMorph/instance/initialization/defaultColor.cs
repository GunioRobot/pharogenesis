defaultColor
	"answer the default color/fill style for the receiver"
		| fill |
	fill _ GradientFillStyle ramp: {0.0
					-> (Color
							r: 0.355
							g: 0.548
							b: 1.0). 1.0
					-> (Color
							r: 0.774
							g: 0.935
							b: 1.0)}.
	fill origin: self bounds topLeft + (61 @ 7).
	fill direction: 33 @ 37.
	fill radial: false.
	^ fill