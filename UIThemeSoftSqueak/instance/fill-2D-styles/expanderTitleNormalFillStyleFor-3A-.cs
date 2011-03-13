expanderTitleNormalFillStyleFor: anExpanderTitle
	"Return the normal expander title fillStyle for the given expander title."
	
	|aColor|
	aColor := anExpanderTitle paneColor.
	^(GradientFillStyle ramp: {
			0.0->Color white. 0.2-> aColor twiceLighter.
			0.8->aColor darker. 1.0->aColor darker duller})
		origin: anExpanderTitle topLeft;
		direction: 0 @ anExpanderTitle height;
		radial: false