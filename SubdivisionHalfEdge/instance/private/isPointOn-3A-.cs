isPointOn: aPoint
	"A predicate that determines if the point x is on the edge e.
	The point is considered on if it is in the EPS-neighborhood
	of the edge"
	| v1 v2 u v |
	v1 := aPoint - self origin.
	v2 := self destination - self origin.
	u := v1 dotProduct: v2.
	v := v1 crossProduct: v2.
	^(u isZero and:[v isZero])