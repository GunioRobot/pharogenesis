initialize
	super initialize.
	color _ GradientFillStyle ramp: {0.0 -> Color green. 0.5 -> Color yellow. 1.0 -> Color red}.
	color radial: true.
	borderColor _ GradientFillStyle ramp: {0.0 -> Color black. 1.0 -> Color white}.
	borderWidth _ 10.
	self extent: 100@100.