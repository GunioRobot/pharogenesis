closestEdgeTo: aHalfedge
	| minAngle angle minEdge |
	minAngle _ 2 * Float pi.
	(self incidentEdgesAt: aHalfedge origin)
		do: 
			[:edge | 
			angle _ edge angleTo: aHalfedge.
			angle < minAngle
				ifTrue: 
					[minAngle _ angle.
					minEdge _ edge]].
	^ minEdge