dropListDisabledFillStyleFor: aDropList
	"Return the disabled fillStyle for the given dropList."
	
	|c|
	c := aDropList paneColor alphaMixed: 0.3 with: Color white.
	^(GradientFillStyle ramp: {
			0.0->c darker duller.
			0.2-> c darker.
			0.8->c twiceLighter.
			1.0->c darker})
		origin: aDropList topLeft;
		direction: 0 @ aDropList height;
		radial: false