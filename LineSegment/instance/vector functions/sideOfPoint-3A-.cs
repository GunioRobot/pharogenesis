sideOfPoint: aPoint
	"Return the side of the receiver this point is on. The method returns
		-1: if aPoint is left
		 0: if aPoint is on
		+1: if a point is right
	of the receiver."
	| dx dy px py |
	dx _ end x - start x.
	dy _ end y - start y.
	px _ aPoint x - start x.
	py _ aPoint y - start y.
	^((dx * py) - (px * dy)) sign
"
	(LineSegment from: 0@0 to: 100@0) sideOfPoint: 50@-50.
	(LineSegment from: 0@0 to: 100@0) sideOfPoint: 50@50.
	(LineSegment from: 0@0 to: 100@0) sideOfPoint: 50@0.
"
