transformY: aFloatArray 
	| focus subArray dMaxY |
	focus := srcExtent y asFloat / 2.
	dMaxY := (aFloatArray first) <= focus 
				ifTrue: [0.0 - focus]
				ifFalse: [focus].
	subArray := self 
				g: (aFloatArray copyFrom: 1 to: gridNum x + 1)
				max: dMaxY
				focus: focus.
	aFloatArray 
		replaceFrom: 1
		to: gridNum x + 1
		with: subArray
		startingAt: 1