sliderNormalFillStyleFor: aSlider
	"Return the normal fillStyle for the given slider."
	
	|c|
	c := aSlider paneColor alphaMixed: 0.1 with: Color white.
	^(GradientFillStyle ramp: {
			0.0->c darker duller.
			0.2-> c lighter.
			0.8->c twiceLighter.
			1.0->c darker})
		origin: aSlider topLeft;
		direction: 0 @ aSlider height;
		radial: false