textEditorDisabledFillStyleFor: aTextEditor
	"Return the disabled fillStyle for the given text editor."
	
	|c|
	c := aTextEditor paneColor alphaMixed: 0.3 with: Color white.
	^(GradientFillStyle ramp: {
			0.0->c darker duller.
			0.1-> c darker.
			0.9->c twiceLighter.
			1.0->c darker})
		origin: aTextEditor topLeft;
		direction: 0 @ aTextEditor height;
		radial: false