curveBounds
	"Compute the bounds from actual curve traversal, with leeway for borderWidth.
	Also note the next-to-first and next-to-last points for arrow directions."
	| curveBounds |
	self computeCurve.
	curveBounds _ vertices first corner: vertices last.
	ntfPoint _ nil.
	self lineSegmentsDo:
		[:p1 :p2 | ntfPoint == nil ifTrue: [ntfPoint _ p2 asIntegerPoint].
		curveBounds _ curveBounds encompass: p2 asIntegerPoint.
		ntlPoint _ p1 asIntegerPoint].
	^ curveBounds expandBy: borderWidth+1//2