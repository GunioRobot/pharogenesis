buttonSelectedPressedFillStyleFor: aButton
	"Return the button selected pressed fillStyle for the given color."

	|aColor c|
	aColor := aButton colorToUse.
	c := aColor luminance > 0.3
		ifTrue: [aColor blacker]
		ifFalse: [aColor whiter].
	^(GradientFillStyle ramp: {
			0.0->Color white. 0.2->c twiceLighter.
			0.8->c darker. 1.0->c darker duller})
		origin: aButton bounds origin;
		direction: 0 @ aButton height;
		radial: false