curveBounds
	| curveBounds pointAfterFirst pointBeforeLast |
	smoothCurve 
		ifFalse: 
			[^(Rectangle encompassing: vertices) expandBy: (borderWidth + 1) // 2].

	"Compute the bounds from actual curve traversal, with leeway for borderWidth.
	Also note the next-to-first and next-to-last points for arrow directions."
	curveState := nil.	"Force recomputation"
	curveBounds := vertices first corner: vertices last.
	pointAfterFirst := nil.
	self lineSegmentsDo: 
			[:p1 :p2 | 
			pointAfterFirst isNil 
				ifTrue: 
					[pointAfterFirst := p2 asIntegerPoint.
					curveBounds := curveBounds encompass: p1 asIntegerPoint].
			curveBounds := curveBounds encompass: p2 asIntegerPoint.
			pointBeforeLast := p1 asIntegerPoint].
	curveState at: 2 put: pointAfterFirst.
	curveState at: 3 put: pointBeforeLast.
	^curveBounds expandBy: (borderWidth + 1) // 2