updateColor
	| fill title |
	Preferences gradientMenu
		ifFalse: [^ self].
	""
	fill _ GradientFillStyle ramp: {0.0 -> Color white. 1 -> self color}.
	""
	fill
		radial: false;
		origin: self topLeft;
		direction: 0 @ self height.
	""
	self fillStyle: fill.
	" 
	update the title color"
	title _ self allMorphs
				detect: [:each | each hasProperty: #titleString]
				ifNone: [^ self].
	""
	fill _ GradientFillStyle ramp: {0.0 -> title color twiceLighter. 1 -> title color twiceDarker}.
	""
	fill
		origin: title topLeft;
		direction: title width @ 0.
	""
	title fillStyle: fill