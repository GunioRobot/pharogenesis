drawPostscriptOn: aCanvas 
	"Display the receiver, a spline curve, approximated by straight line segments."
	vertices size < 1 ifTrue: [self error: 'a polygon must have at least one point'].
	aCanvas drawPolygon: self getVertices color: self color borderWidth:self borderWidth borderColor: self borderColor.