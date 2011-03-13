textEditorNormalFillStyleFor: aTextEditor
	"Return the normal fillStyle for the given text editor."
	
	|c|
	c := aTextEditor paneColor alphaMixed: 0.1 with: Color white.
	^(GradientFillStyle ramp: {
			0.0->c darker duller.
			0.1-> c lighter.
			0.9->c twiceLighter.
			1.0->c darker})
		origin: aTextEditor topLeft;
		direction: 0 @ aTextEditor height;
		radial: false