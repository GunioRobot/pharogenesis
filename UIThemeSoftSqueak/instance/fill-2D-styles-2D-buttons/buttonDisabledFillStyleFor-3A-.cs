buttonDisabledFillStyleFor: aButton
	"Return the disabled button fillStyle for the given color."

	|c|
	c :=  aButton colorToUse twiceLighter whiter.
	^(GradientFillStyle ramp: {
			0.0->Color white.
			0.2->c twiceLighter.
			0.8->c darker.
			1.0->c darker duller})
		origin: aButton bounds origin;
		direction: 0 @ aButton height;
		radial: false