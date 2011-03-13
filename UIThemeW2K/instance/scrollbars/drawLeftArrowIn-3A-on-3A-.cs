drawLeftArrowIn: aRectangle on: aCanvas

	| aTriangleRect aSlope theCenter aWidth aHalfHeight anEnabledColor |
	
	anEnabledColor := Color black.
	
	aWidth := ((aRectangle width) * 0.5) asInteger.
	aHalfHeight := (aWidth) asInteger.
	aHalfHeight <= 0 ifTrue:[^nil].
	theCenter := aRectangle center.
	aTriangleRect := (Rectangle origin: theCenter extent: 0@0) translateBy: (((aHalfHeight/3) asInteger negated)@0).
	aSlope := aWidth/aHalfHeight.
	[aTriangleRect height < aWidth] whileTrue: 
		[		
				aCanvas line: aTriangleRect bottomRight to: aTriangleRect topRight color: anEnabledColor.
				aTriangleRect := aTriangleRect outsetBy: (1 min: ((aSlope + 0.5) asInteger)).
		].
	aCanvas line: aTriangleRect center to: aTriangleRect center color: anEnabledColor.
	