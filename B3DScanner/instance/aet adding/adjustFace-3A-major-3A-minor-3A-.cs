adjustFace: face major: majorEdge minor: minorEdge
	"Set the left/right edge of the face to the appropriate edges"
	(majorEdge == nil or:[minorEdge == nil]) 
		ifTrue:[^self error:'Edges must be non-nil'].
	majorEdge xValue = minorEdge xValue ifTrue:[
		"Most likely case. Both edges start at the same point.
		Use dx/dy slope for determining which one is left and which one is right.
		NOTE: 	We have this already computed during face>>initializePass1.
				The value to use is the x increment at each scan line.
		NOTE2: 	There is also a border case when minorEdge is actually the lower
				edge of the triangle. If both xValues are equal, then the triangle
				is degenerate (e.g., it's area is zero) in which case the meaning of
				'left' or 'right' does not matter at all (and can thus be handled
				by this simple test)."
		majorEdge xIncrement <= minorEdge xIncrement
			ifTrue:[	face leftEdge: majorEdge.
					face rightEdge: minorEdge]
			ifFalse:[	face leftEdge: minorEdge.
					face rightEdge: majorEdge].
	] ifFalse:[
		"If the x values are not equal, simply use the edge with the smaller x value as 'left' edge"
		majorEdge xValue < minorEdge xValue 
			ifTrue:[	face leftEdge: majorEdge.
					face rightEdge: minorEdge]
			ifFalse:[	face leftEdge: minorEdge.
					face rightEdge: majorEdge].
	].