crossEdgeEvent: evt
	| evtPoint edge index other |
	lastIntersections 
		ifNil:[lastIntersections _ Array with: evt]
		ifNotNil:[
			(lastIntersections anySatisfy:
				[:old| old edge == evt edge and:[old crossedEdge == evt crossedEdge]]) ifTrue:[^self].
			lastIntersections _ lastIntersections copyWith: evt].
	evtPoint _ evt position.
	edge _ evt edge.
	self recordIntersection: edge with: evt crossedEdge at: evtPoint.
	Debug == true ifTrue:[
		self debugDrawLine: edge with: evt crossedEdge color: Color red.
		self debugDrawLine: edge with: evt crossedEdge color: Color blue.
		self debugDrawLine: edge with: evt crossedEdge color: Color red.
		self debugDrawLine: edge with: evt crossedEdge color: Color blue].
	index _ self firstIndexForInserting: evtPoint.
	[other _ activeEdges at: index.
	other == edge] whileFalse:[index _ index + 1].
	"Swap edges at index"
	"self assert:[(activeEdges at: index+1) == evt crossedEdge]."
	other _ activeEdges at: index+1.
	activeEdges at: index+1 put: edge.
	activeEdges at: index put: other.
	"And compute new intersections"
	self computeIntersectionAt: index-1 belowOrRightOf: evtPoint.
	self computeIntersectionAt: index+1 belowOrRightOf: evtPoint.