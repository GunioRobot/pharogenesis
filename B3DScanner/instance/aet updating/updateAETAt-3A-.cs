updateAETAt: yValue
	"Advance all entries in the AET by one scan line step"
	| edge count |
	aet reset.
	[aet atEnd] whileFalse:[
		edge _ aet next.
		count _ edge nLines - 1.
		count = 0 ifTrue:[
			"Remove the edge from the AET.
			If the continuation flag is set, create new (lower) edge(s)."
			(edge vertex1 windowPosY bitShift: -12) = yValue
				ifFalse:[self error:'Edge exceeds range'].
			aet removeFirst.
			(edge flags anyMask: FlagContinueLeftEdge)
				ifTrue:[self addLowerEdge: edge fromFace: edge leftFace].
			(edge flags anyMask: FlagContinueRightEdge) 
				ifTrue:[self addLowerEdge: edge fromFace: edge rightFace].
			(edge flags anyMask: FlagEdgeLeftMajor)
				ifTrue:[nFaces _ nFaces - 1].
			(edge flags anyMask: FlagEdgeRightMajor)
				ifTrue:[nFaces _ nFaces - 1].
		] ifFalse:[
			"Edge continues. Adjust the number of scan lines remaining
			and update the incremental values. Make sure that the sorting
			order of the AET is not getting confused."
			edge nLines: count. "# of scan lines"
			edge stepToNextLine. "update incremental values"
			aet resortFirst. "make sure edge is sorted right"
		].
	].
