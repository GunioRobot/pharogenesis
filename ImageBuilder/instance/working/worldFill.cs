worldFill
	"
	FullImageTools new worldFill.
	"
	| fill |
	fill := GradientFillStyle ramp: {0.0 -> Color blue muchLighter. 1.0 -> Color white}.
	fill origin: 0 @ 0.
	fill direction: 0 @ 768.
	World fillStyle: fill