textFieldDisabledFillStyleFor: aTextField
	"Return the disabled fillStyle for the given text field."
	
	|c|
	c := aTextField paneColor alphaMixed: 0.3 with: Color white.
	^(GradientFillStyle ramp: {
			0.0->c darker duller.
			0.2-> c darker.
			0.8->c twiceLighter.
			1.0->c darker})
		origin: aTextField topLeft;
		direction: 0 @ aTextField height;
		radial: false