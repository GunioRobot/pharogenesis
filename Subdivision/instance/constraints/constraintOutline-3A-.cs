constraintOutline: pointList
	"Make sure all line segments in the given closed outline appear in the triangulation."
	| lastPt nextPt lastEdge nextEdge outPoints |
	outlineThreshold ifNil:[outlineThreshold _ 1.0e-3].
	lastPt _ pointList last.
	lastEdge _ self locatePoint: lastPt.
	lastEdge origin = lastPt 
		ifFalse:[lastEdge _ lastEdge symmetric].
	outPoints := WriteStream on: (Array new: pointList size).
	1 to: pointList size do:[:i|
		nextPt _ pointList at: i.
		lastPt = nextPt ifFalse:[
			nextEdge _ self assureEdgeFrom: lastPt to: nextPt lastEdge: lastEdge into: outPoints.
			outPoints nextPut: nextPt.
			nextEdge ifNil:[
				nextEdge _ self locatePoint: nextPt.
				lastEdge destination = nextPt 
					ifFalse:[lastEdge _ lastEdge symmetric].
			].
			lastEdge _ nextEdge symmetric originNext].
		lastPt _ nextPt.
	].
	^outPoints contents