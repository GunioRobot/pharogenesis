cSquaredDistanceFrom: aPoint to: bPoint
	"arguments are pointer to ints paired as x,y coordinates of points"
	| aPointX aPointY bPointX bPointY xDiff yDiff |
	self var: #aPoint declareC: 'int *  aPoint'.
	self var: #bPoint declareC: 'int *  bPoint'.
	aPointX _ aPoint at: 0.
	aPointY _ aPoint at: 1.
	bPointX _ bPoint at: 0.
	bPointY _ bPoint at: 1.

	xDiff _ bPointX - aPointX.
	yDiff _ bPointY - aPointY.
	^ xDiff * xDiff + (yDiff * yDiff)