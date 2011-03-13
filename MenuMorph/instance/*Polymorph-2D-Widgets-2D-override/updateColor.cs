updateColor
	"Update the color of the menu."
	
	| fill title bc |
	Preferences gradientMenu
		ifFalse: [^ self].
	bc := self valueOfProperty: #basicColor ifAbsent: [self theme menuColor].
	fill := GradientFillStyle
		ramp: {0.0 -> (bc alphaMixed: 0.2 with: Color white). 1.0 -> bc}.
	fill
		radial: false;
		origin: self topLeft;
		direction: 0 @ self height.
	self fillStyle: fill.
	"update the title color"
	title := self allMorphs
				detect: [:each | each hasProperty: #titleString]
				ifNone: [^ self].
	fill := GradientFillStyle ramp: {0.0 -> title color twiceLighter. 1 -> title color twiceDarker}.
	fill
		origin: title topLeft;
		direction: title width @ 0.
	title fillStyle: fill