endEdgeEvent: evt
	| evtPoint edge index other |
	evtPoint _ evt position.
	edge _ evt edge.
	Debug == true ifTrue:[self debugDrawLine: edge color: Color green].
	index _ self firstIndexForInserting: evtPoint.
	[other _ activeEdges at: index.
	other == edge] whileFalse:[index _ index + 1].
	"Remove edge at index"
	activeEdges removeAt: index.
	self computeIntersectionAt: index-1 belowOrRightOf: evtPoint.