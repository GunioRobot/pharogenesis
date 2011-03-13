windowActiveTitleFillStyleFor: aWindow
	"Return the window active title fillStyle for the given window."
	
	|aColor|
	aColor := aWindow paneColorToUse.
	^(GradientFillStyle ramp: {
			0.0->(aColor alphaMixed: 0.3 with: (Color white alpha: aColor alpha)).
			0.2-> aColor twiceLighter.
			0.8->aColor darker.
			1.0->aColor darker duller})	
		origin: aWindow labelArea topLeft;
		direction: 0 @ aWindow labelHeight;
		radial: false