markExteriorEdges
	"Recursively flag all edges that are known to be exterior edges.
	If the outline shape is not simple this may result in marking all edges."
	| firstEdge |
	firstEdge _ self locatePoint: point1.
	firstEdge origin = point1 
		ifFalse:[firstEdge _ firstEdge symmetric].
	firstEdge markExteriorEdges: (stamp _ stamp + 1).