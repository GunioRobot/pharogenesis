updateColor
	| fill title |
	Preferences gradientMenu
		ifFalse: [^ self].
	""
	fill := GradientFillStyle ramp: {0.0 -> self color lighter. 1 -> self color darker}.
	""
	fill origin: self topLeft.
	fill direction: self width @ 0.
	""
	self fillStyle: fill.
	" 
	update the title color"
	title := self allMorphs
				detect: [:each | each hasProperty: #titleString]
				ifNone: [^ self].
	""
	fill := GradientFillStyle ramp: {0.0 -> title color twiceLighter. 1 -> title color twiceDarker}.
	""
	fill origin: title topLeft.
	fill direction: title width @ 0.
	""
	title fillStyle: fill