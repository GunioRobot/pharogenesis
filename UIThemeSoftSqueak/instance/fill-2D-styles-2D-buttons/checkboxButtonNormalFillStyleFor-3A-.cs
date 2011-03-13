checkboxButtonNormalFillStyleFor: aCheckboxButton
	"Return the normal checkbox button fillStyle for the given button."
	
	|c|
	c := aCheckboxButton colorToUse
		alphaMixed: 0.1
		with: Color white.
	^(GradientFillStyle ramp: {
			0.0->c darker duller.
			0.2->c darker.
			0.8->c twiceLighter.
			1.0->c})
		origin: aCheckboxButton bounds origin;
		direction: 0 @ aCheckboxButton height;
		radial: false