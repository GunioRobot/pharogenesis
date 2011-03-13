curveBounds

	| curveBounds pointAfterFirst pointBeforeLast |
	smoothCurve ifFalse: [^ (Rectangle encompassing: vertices) expandBy: borderWidth+1//2].

	"Compute the bounds from actual curve traversal, with leeway for borderWidth.
	Also note the next-to-first and next-to-last points for arrow directions."

	curveState _ nil.  "Force recomputation"
	curveBounds _ vertices first corner: vertices last.
	pointAfterFirst _ nil.
	self lineSegmentsDo:
		[:p1 :p2 | pointAfterFirst == nil ifTrue: [pointAfterFirst _ p2 asIntegerPoint].
		curveBounds _ curveBounds encompass: p2 asIntegerPoint.
		pointBeforeLast _ p1 asIntegerPoint].
	curveState at: 2 put: pointAfterFirst.
	curveState at: 3 put: pointBeforeLast.
	^ curveBounds expandBy: borderWidth+1//2