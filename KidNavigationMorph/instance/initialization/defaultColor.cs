defaultColor
	"answer the default color/fill style for the receiver"
	| result |
	result _ GradientFillStyle ramp: {0.0
					-> (Color
							r: 0.032
							g: 0.0
							b: 0.484). 1.0
					-> (Color
							r: 0.194
							g: 0.032
							b: 1.0)}.
	result origin: self bounds topLeft.
	result direction: 0 @ 200.
	result radial: false.
	^ result