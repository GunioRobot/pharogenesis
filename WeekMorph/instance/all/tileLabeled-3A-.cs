tileLabeled: labelString
	| onColor offColor |
	offColor _ Color r: 0.4 g: 0.8 b: 0.6.
	onColor _ offColor mixed: 1/2 with: Color white.
	^ (SimpleSwitchMorph newWithLabel: labelString)
		offColor: offColor;
		onColor: onColor;
		borderWidth: 1;
		useSquareCorners;
		extent: 23 @ 19