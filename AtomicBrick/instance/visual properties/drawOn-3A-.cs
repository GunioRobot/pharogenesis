drawOn: aCanvas 
	| rectBound rectColor |
	rectBound _ self bounds.
	rectColor _ self defaultColor.
	aCanvas fillRectangle: rectBound fillStyle: rectColor.
	rectBound _ rectBound insetBy: 1.
	1
		to: (mapStyle isSmallScreen
				ifTrue: [2]
				ifFalse: [4])
		do: [:value | 
			rectColor _ rectColor alphaMixed: 0.75 with: Color white.
			aCanvas fillRectangle: rectBound fillStyle: rectColor.
			rectBound _ rectBound insetBy: 2]