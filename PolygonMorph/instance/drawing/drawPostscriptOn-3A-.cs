drawPostscriptOn: aCanvas 
	"Display the receiver, a spline curve, approximated by straight 
	line segments."
	| array |
	vertices size < 1
		ifTrue: [self error: 'a polygon must have at least one point'].
	array _ self drawArrowsOn: aCanvas.
	closed
		ifTrue: [aCanvas
				drawPolygon: self getVertices
				color: self color
				borderWidth: self borderWidth
				borderColor: self borderColor]
		ifFalse: [self drawBorderOn: aCanvas usingEnds: array].
