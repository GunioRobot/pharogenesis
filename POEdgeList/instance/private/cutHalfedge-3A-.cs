cutHalfedge: anEdge
	anEdge prev next: anEdge opposite next.
	anEdge opposite next prev: anEdge prev.
	anEdge origin halfedge: anEdge opposite next. 