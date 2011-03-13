windowInactiveTitleFillStyleFor: aWindow
	"Return the window inactive title fillStyle for the given window."
	
	|aColor|
	aColor := self windowColor twiceLighter.
	^(GradientFillStyle ramp: {
			0.0->aColor twiceLighter.
			1.0->aColor})	
		origin: aWindow labelArea topLeft;
		direction: 0 @ aWindow labelHeight;
		radial: false