recordIntersection: edge with: other at: evtPoint
	intersections nextPut:
		(Array with: evtPoint
				with: edge referentEdge
				with: other referentEdge).