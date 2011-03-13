updateColor: aMorph color: aColor intensity: anInteger 
	"update the apareance of aMorph"
	| fill |
	Preferences gradientMenu
		ifFalse: [^ self].

	fill _ GradientFillStyle ramp: {0.0 -> Color white. 1 -> aColor}.
	fill radial: false;
		origin: aMorph topLeft;
		direction: 0 @ aMorph height.
	aMorph fillStyle: fill