tile
	| onColor offColor |
	offColor _ Color r: 0.4 g: 0.8 b: 0.6.
	onColor _ offColor alphaMixed: 1/2 with: Color white.
	^ SimpleSwitchMorph new
		offColor: offColor;
		onColor: onColor;
		borderWidth: 1;
		useSquareCorners;
		extent: tileRect extent