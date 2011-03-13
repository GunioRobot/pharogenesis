arrowBoundsAt: endPoint from: priorPoint 
	"Answer a triangle oriented along the line from priorPoint to endPoint."
	| d v angle wingBase arrowSpec length width |
	v _ endPoint - priorPoint.
	angle _ v degrees.
	d _ borderWidth max: 1.
	arrowSpec _ self valueOfProperty: #arrowSpec ifAbsent: [5@4].
	length _ arrowSpec x abs.  width _ arrowSpec y abs.
	wingBase _ endPoint + (Point r: d * length degrees: angle + 180.0).
	arrowSpec x >= 0
		ifTrue: [^ {	endPoint.
					wingBase + (Point r: d * width degrees: angle + 125.0).
					wingBase + (Point r: d * width degrees: angle - 125.0) }]
		ifFalse: ["Negative length means concave base."
				^ {	endPoint.
					wingBase + (Point r: d * width degrees: angle + 125.0).
					wingBase.
					wingBase + (Point r: d * width degrees: angle - 125.0) }]