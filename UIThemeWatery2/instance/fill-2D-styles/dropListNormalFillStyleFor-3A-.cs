dropListNormalFillStyleFor: aDropList
	"Return the normal fillStyle for the given drop list."
	
	|c|
	c := self windowColor.
	^(BoundedGradientFillStyle ramp: {
			0.0->c twiceDarker.
			0.05-> c lighter.
			0.15-> Color white.
			1.0->Color white})
		origin: aDropList topLeft;
		extent: aDropList width - aDropList buttonMorph width @ aDropList height;
		direction: 0 @ aDropList height;
		radial: false