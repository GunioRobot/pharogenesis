drawUpArrowIn: aRectangle on: aCanvas

	| aHeight aHalfWidth aTriangleRect aSlope theCenter anEnabledColor |
	
	anEnabledColor := Color black.
	aHeight := ((aRectangle height) * 0.5) asInteger.
	aHalfWidth := (aHeight) asInteger.
	aHalfWidth <= 0 ifTrue:[^nil].
	theCenter := aRectangle center.
	aTriangleRect := (Rectangle origin: theCenter extent: 0@0) translateBy: (0@((aHalfWidth/3.5) asInteger negated)).
	aSlope := aHeight/aHalfWidth.
	[aTriangleRect width < aHeight] whileTrue: 
		[		
				aCanvas line: aTriangleRect bottomLeft to: aTriangleRect bottomRight color: anEnabledColor.
				aTriangleRect := aTriangleRect outsetBy: (1 min: ((aSlope + 0.5) asInteger)).
		].
	aCanvas line: aTriangleRect center to: aTriangleRect center color: anEnabledColor.
	