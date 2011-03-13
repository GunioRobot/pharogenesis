buttonNormalFillStyleFor: aButton
	"Return the normal button fillStyle for the given button."
	
	|aColor|
	aColor := self buttonColorFor: aButton.
	^(GradientFillStyle ramp: {
			0.0->Color white.
			0.2->aColor twiceLighter.
			0.8->aColor darker.
			1.0->aColor darker duller})
		origin: aButton bounds origin;
		direction: 0 @ aButton height;
		radial: false