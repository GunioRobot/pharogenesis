buttonSelectedFillStyleFor: aButton
	"Return the button selected fillStyle for the given color."
	
	|aColor|
	aColor := aButton colorToUse.
	^(GradientFillStyle ramp: {
			0.0->aColor darker duller. 0.2->aColor darker.
			0.8->aColor twiceLighter. 1.0->Color white})
		origin: aButton bounds origin;
		direction: 0 @ aButton height;
		radial: false