buttonSelectedDisabledFillStyleFor: aButton
	"Return the button selected disabled fillStyle for the given color."
	
	|aColor c|
	aColor := aButton colorToUse.
	c :=  aColor twiceLighter whiter.
	^(GradientFillStyle ramp: {
			0.0->c darker duller. 0.2->c darker.
			0.8->c twiceLighter. 1.0->Color white})
		origin: aButton bounds origin;
		direction: 0 @ aButton height;
		radial: false