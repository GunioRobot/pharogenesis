attachHalfedge: aHalfedge 
	| left right |
	left _ self closestEdgeTo: aHalfedge.
	right _ left prev.
	aHalfedge prev: right.
	right next: aHalfedge.
	aHalfedge opposite next: left.
	left prev: aHalfedge opposite