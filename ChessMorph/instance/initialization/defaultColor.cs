defaultColor
	"answer the receiver's default color"
	| result |
	result _ GradientFillStyle ramp: {0.0
					-> (Color
							r: 0.05
							g: 0.5
							b: 1.0). 1.0
					-> (Color
							r: 0.85
							g: 0.95
							b: 1.0)}.
	result origin: self bounds origin;
		 direction: self extent.
	result radial: false.
	^ result