computeIntersectionAt: leftIndex belowOrRightOf: aPoint
	| leftEdge rightEdge pt evt |
	leftIndex < 1 ifTrue:[^self].
	leftIndex >= activeEdges size ifTrue:[^self].
	leftEdge _ activeEdges at: leftIndex.
	rightEdge _ activeEdges at: leftIndex+1.
	Debug == true ifTrue:[
		self debugDrawLine: leftEdge with: rightEdge color: Color yellow.
		self debugDrawLine: leftEdge with: rightEdge color: Color blue.
		self debugDrawLine: leftEdge with: rightEdge color: Color yellow.
		self debugDrawLine: leftEdge with: rightEdge color: Color blue.
	].
	pt _ self intersectFrom: leftEdge start to: leftEdge end with: rightEdge start to: rightEdge end.
	pt ifNil:[^self].
	pt y < aPoint y ifTrue:[^self].
	(pt y = aPoint y and:[pt x <= aPoint x]) ifTrue:[^self].
	Debug == true ifTrue:[self debugDrawPoint: pt].
	evt _ LineIntersectionEvent type: #cross position: pt segment: leftEdge.
	evt crossedEdge: rightEdge.
	events add: evt.