drawArrowOn: aCanvas at: endPoint from: priorPoint
	"Draw a triangle oriented along the line from priorPoint to endPoint."
	| d v pts angle |
	d _ borderWidth max: 1.
	v _ endPoint - priorPoint.
	angle _ v theta radiansToDegrees.
	pts _ Array with: (endPoint + (borderWidth//2) + (Point r: d*5 degrees: angle))
				with: (endPoint + (borderWidth//2) + (Point r: d*4 degrees: angle + 135.0))
				with: (endPoint + (borderWidth//2) + (Point r: d*4 degrees: angle - 135.0)).
	aCanvas drawPolygon: pts fillStyle: borderColor.
